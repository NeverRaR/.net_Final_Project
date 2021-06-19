using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyaBackend.Utils;
using SyaBackend.Services;
using SyaBackend.Models;
using SyaBackend.Views;
using SyaBackend.Requests;
using StackExchange.Redis;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SyaBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {

        private readonly SyaDbContext _dataBase;
        private readonly IDatabase _redis;

        public FavoriteController(SyaDbContext context, RedisClient client)
        {
            _dataBase = context;
            _redis = client.GetDatabase();
        }

        // GET: api/<FavoriteController>
        [HttpPost("CreateFavorite")]
        public int CreateFavorite([FromBody] CreateFavoriteDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null )
            {
                return -1;
            }
            Favorite favorite = new Favorite();
            favorite.Name = body.FavoriteName;
            favorite.User = user;
            _dataBase.Favorites.Add(favorite);
            _dataBase.SaveChanges();
            return favorite.FavoriteId;   
        }


        [HttpPost("GetFavorite")]
        public FavoriteInfoListByPage GetFavorite([FromBody] PageDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return null;
            }
            var favoriteList = _dataBase.Favorites.Where(f => f.User.UserId == user.UserId);
            return GetWorkStatusListByPage(favoriteList, body.Pagenum, body.Pagesize);
        }

        [HttpPut("UpdateFavorite")]
        public FavoriteInfo UpdateFavorite([FromBody] UpdateFavoriteDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return null;
            }
            Favorite favorite = _dataBase.Favorites.Find(body.FavoriteId);
            if (favorite == null) return null;
            favorite.Name = body.FavoriteName;
            _dataBase.Favorites.Update(favorite);
            _dataBase.SaveChanges();
            return GetFavoriteInfo(favorite);
        }

        [HttpPost("DeleteFavorite")]
        public int DeleteFavorite([FromBody] FavoriteIdDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return 0;
            }
            Favorite favorite = _dataBase.Favorites.Find(body.FavoriteId);
            if (favorite == null) return 0;
           
            _dataBase.Favorites.Remove(favorite);
            _dataBase.SaveChanges();
            return 1;
        }

        [HttpPost("GetFavoriteInfo")]
        public WorkStatusListByPage GetFavoriteInfo([FromBody] FavoriteIdDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return null;
            }
            Favorite favorite = _dataBase.Favorites.Find(body.FavoriteId);
            if (favorite == null)  return null;
            _dataBase.Entry(favorite).Collection(f => f.FavoriteHasWorks).Load();
            WorkStatusListByPage workStatusListByPage = new WorkStatusListByPage();
            LinkedList<WorkStatus> workStatusList = new LinkedList<WorkStatus>();
            foreach ( var favoriteHasWork in favorite.FavoriteHasWorks)
            {
                Work work = _dataBase.Works.Find(favoriteHasWork.WorkId);
                workStatusList.AddLast(GetWorkStatus(work));
            }
            workStatusListByPage.Worklist = workStatusList;
            return workStatusListByPage;
        }

        [HttpPost("AddFavoriteWork")]
        public int AddFavoriteWork([FromBody] FavoriteWorkDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return -1;
            }
            Favorite favorite = _dataBase.Favorites.Find(body.FavoriteId);
            if (favorite == null) return -1;
            Work work = _dataBase.Works.Find(body.WorkId);
            if (work == null) return -1;
            FavoriteHasWork favoriteHasWork = _dataBase.FavoriteHasWorks.Find(work.WorkId, favorite.FavoriteId);
            if (favoriteHasWork != null) return -1;
            favoriteHasWork = new FavoriteHasWork();
            favoriteHasWork.WorkId = work.WorkId;
            favoriteHasWork.FavoriteId = favorite.FavoriteId;
            _dataBase.FavoriteHasWorks.Add(favoriteHasWork);
            _dataBase.SaveChanges();

            return 1;
        }

        [HttpPost("DeleteFavoriteWork")]
        public int DeleteFavoriteWork([FromBody] FavoriteWorkDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return -1;
            }
            Favorite favorite = _dataBase.Favorites.Find(body.FavoriteId);
            if (favorite == null) return -1;
            Work work = _dataBase.Works.Find(body.WorkId);
            if (work == null) return -1;
            FavoriteHasWork favoriteHasWork = _dataBase.FavoriteHasWorks.Find(work.WorkId, favorite.FavoriteId);
            if (favoriteHasWork == null) return -1;
           
            _dataBase.FavoriteHasWorks.Remove(favoriteHasWork);
            _dataBase.SaveChanges();

            return 1;
        }

        private FavoriteInfoListByPage GetWorkStatusListByPage(IEnumerable<Favorite> favoriteList, int pageNum, int pageSize)
        {
            int totalPage = 1 + (favoriteList.Count() - 1) / pageSize;
            LinkedList<FavoriteInfo> favoriteInfoList = new LinkedList<FavoriteInfo>();
            var favoriteListByPage = favoriteList.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            foreach (var favorite in favoriteListByPage)
            {
                _dataBase.Entry(favorite).Reference(f => f.User).Load();
                FavoriteInfo favoriteInfo = GetFavoriteInfo(favorite);
                favoriteInfoList.AddLast(favoriteInfo);
            }
            FavoriteInfoListByPage favoriteInfoListByPage = new FavoriteInfoListByPage();
            favoriteInfoListByPage.Totalpage = totalPage;
            favoriteInfoListByPage.FavoriteItem = favoriteInfoList;
            favoriteInfoListByPage.Pagenum = pageNum;

            return favoriteInfoListByPage;
        }

        private FavoriteInfo GetFavoriteInfo(Favorite favorite)
        {
            FavoriteInfo favoriteInfo = new FavoriteInfo();
            if (favorite == null)
            {
                return favoriteInfo;
            }

            favoriteInfo.FavoriteId = favorite.FavoriteId;
            favoriteInfo.FavoriteName = favorite.Name;
            favoriteInfo.UserId = favorite.User.UserId;

            favoriteInfo.WorkNum = _dataBase.FavoriteHasWorks.Where(f => f.FavoriteId == favorite.FavoriteId).Count();
            return favoriteInfo;
        }

        private WorkStatus GetWorkStatus(Work work)
        {
            WorkStatus workStatus = new WorkStatus();
            if (work == null)
            {
                return workStatus;
            }

            workStatus.Address = work.Address;
            workStatus.Cover = work.Cover;
            workStatus.EndDay = work.EndDay;
            workStatus.EndTime = work.EndTime;
            workStatus.StartDay = work.StartDay;
            workStatus.StartTime = work.StartTime;
            workStatus.Salary = work.Salary;
            workStatus.WeekDay = work.WeekDay;
            workStatus.WorkName = work.Name;
            workStatus.WorkDescription = work.Description;
            workStatus.WorkId = work.WorkId;

            workStatus.CollectNum = _dataBase.FavoriteHasWorks.Where(f => f.WorkId == work.WorkId).Count();
            workStatus.LikesNum = _dataBase.Likes.Where(l => l.WorkId == work.WorkId).Count();
            workStatus.TotalTime = work.GetTotalTime();


            return workStatus;

        }

    }
}
