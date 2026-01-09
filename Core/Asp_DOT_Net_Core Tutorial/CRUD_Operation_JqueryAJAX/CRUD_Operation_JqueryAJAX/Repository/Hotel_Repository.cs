using CRUD_Operation_JqueryAJAX.Configuration;
using CRUD_Operation_JqueryAJAX.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operation_JqueryAJAX.Repository
{
    public class Hotel_Repository : IHotel_Repository
    {
        private readonly HotelDbContext _context;
        public Hotel_Repository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<List<HotelModel>> getHotelDataList()
        {
            return await _context.tbl_HotelData
                .Where(x => x.Is_deleted == 0)
                .OrderByDescending(x => x.CustomerId)
                .ToListAsync();
        }

        public async Task<int> AddOrderItems(HotelModel modelObj)
        {
            modelObj.OrderDate = DateTime.Now;
            modelObj.Is_deleted = 0;
            _context.tbl_HotelData.Add(modelObj);
            return await _context.SaveChangesAsync();
        }

        public async Task<HotelModel> getOrderDetailsByCustId(int custId)
        {
            var custOrderData = await _context.tbl_HotelData.FindAsync(custId);
            HotelModel model = new HotelModel();
            if (custOrderData != null)
            {
                model = custOrderData;
            }
            return model;
        }

        public async Task<int> UpdateOrderItems(HotelModel modelObj)
        {
            _context.tbl_HotelData.Update(modelObj);
            return await _context.SaveChangesAsync();
        }

        public async Task<HotelModel> ViewOrderDetailsById(int custId)
        {
            var custOrderData = await _context.tbl_HotelData.FindAsync(custId);
            HotelModel model = new HotelModel();
            if (custOrderData != null)
            {
                model = custOrderData;
            }
            return model;
        }

        public async Task<int> DeleteOrderItem(int custId)
        {
            var Data = _context.tbl_HotelData.Find(custId);
            if (Data != null)
            {
                Data.Is_deleted = 1;
                _context.tbl_HotelData.Update(Data);
            }
            return await _context.SaveChangesAsync();
        }
    }
}
