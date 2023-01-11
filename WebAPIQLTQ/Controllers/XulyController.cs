using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIQLTQ.Models;

namespace WebAPIQLTQ.Controllers
{
    public class XulyController : ApiController
    {
        [Route("api/GetColorList")]
        [HttpGet]
        public IHttpActionResult GetColorList()
        {
            try
            {
                DataTable tb = Database.GetColorList();
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/GetIconList")]
        [HttpGet]
        public IHttpActionResult GetIconList()
        {
            try
            {
                DataTable tb = Database.GetIconList();
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/User/Login")]
        [HttpGet]
        public IHttpActionResult DangNhap(string username, string password)
        {
            try
            {
                User u = Database.Login(username, password);

                return Ok(u);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/User/Signup")]
        [HttpPost]
        public IHttpActionResult Signup(User u)
        {
            try
            {
                User kq = Database.Signup(u);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/User/UpdateUserInfo")]
        [HttpPost]
        public IHttpActionResult UpdateUserInfo(User u)
        {
            try
            {
                int kq = Database.UpdateUserInfo(u);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/Category/GetCategoryList")]
        [HttpGet]
        public IHttpActionResult GetCategoryList(int userId)
        {
            try
            {
                DataTable tb = Database.GetCategoryList(userId);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/Category/CreateCategory")]
        [HttpPost]
        public IHttpActionResult CreateCategory(Category ct)
        {
            try
            {
                int kq = Database.CreateCategory(ct);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/Category/GetEntryCateogry")]
        [HttpPost]
        public IHttpActionResult GetEntryCateogry(Category ct)
        {
            try
            {
                int tb = Database.GetEntryCateogry(ct);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/Category/UpdateCategory")]
        [HttpPost]
        public IHttpActionResult UpdateCategory(Category ct)
        {
            try
            {
                int kq = Database.UpdateCategory(ct);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/Category/DeleteCategory")]
        [HttpPost]
        public IHttpActionResult DeleteCategory(Category ct)
        {
            try
            {
                int kq = Database.DeleteCategory(ct);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/Habit/GetHabitList")]
        [HttpGet]
        public IHttpActionResult GetHabitList(int userId)
        {
            try
            {
                DataTable tb = Database.GetHabitList(userId);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/Habit/GetHabitsByDate")]
        [HttpGet]
        public IHttpActionResult GetHabitsByDate(int userId, DateTime date)
        {
            try
            {
                //string stringDate = date.ToString("yyyy-mm-dd");
                DataTable tb = Database.GetHabitsByDate(userId, date);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/Habit/CreateHabit")]
        [HttpPost]
        public IHttpActionResult CreateHabit(Habit h)
        {
            try
            {
                int kq = Database.CreateHabit(h);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/Habit/UpdateHabit")]
        [HttpPost]
        public IHttpActionResult UpdateHabit(Habit h)
        {
            try
            {
                int kq = Database.UpdateHabit(h);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/Habit/DeleteHabit")]
        [HttpPost]
        public IHttpActionResult DeleteHabit(Habit h)
        {
            try
            {
                int kq = Database.DeleteHabit(h);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/Habit/GetCheckinList")]
        [HttpGet]
        public IHttpActionResult GetCheckin(int habitId)
        {
            try
            {
                DataTable kq = Database.GetCheckinList(habitId);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/Habit/Checkin")]
        [HttpPost]
        public IHttpActionResult Checkin(HabitHistory hh)
        {
            try
            {
                int kq = Database.Checkin(hh);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/Habit/DeleteCheckin")]
        [HttpPost]
        public IHttpActionResult DeleteCheckin(HabitHistory hh)
        {
            try
            {
                int kq = Database.DeleteCheckin(hh);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
