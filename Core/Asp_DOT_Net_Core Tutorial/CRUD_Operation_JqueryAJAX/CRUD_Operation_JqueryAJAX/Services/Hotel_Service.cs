using CRUD_Operation_JqueryAJAX.Models;
using CRUD_Operation_JqueryAJAX.Repository;

namespace CRUD_Operation_JqueryAJAX.Services
{
    public class Hotel_Service : IHotel_Service
    {
        private readonly IHotel_Repository _repository;
        public Hotel_Service(IHotel_Repository repository)
        {
            _repository = repository;
        }

        public async Task<List<HotelModel>> getHotelDataList()
        {
            return await _repository.getHotelDataList();
        }

        public async Task<int> AddOrderItems(HotelModel modelObj)
        {
            return await _repository.AddOrderItems(modelObj);
        }

        public async Task<HotelModel> getOrderDetailsByCustId(int custId)
        {
            return await _repository.getOrderDetailsByCustId(custId);
        }

        public async Task<int> UpdateOrderItems(HotelModel modelObj)
        {
            return await _repository.UpdateOrderItems(modelObj);
        }

        public async Task<HotelModel> ViewOrderDetailsById(int custId)
        {
            return await _repository.ViewOrderDetailsById(custId);
        }

        public async Task<int> DeleteOrderItem(int custId)
        {
            return await _repository.DeleteOrderItem(custId);
        }
    }
}
