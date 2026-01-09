using CRUD_Operation_JqueryAJAX.Models;

namespace CRUD_Operation_JqueryAJAX.Services
{
    public interface IHotel_Service
    {
        Task<List<HotelModel>> getHotelDataList();

        Task<int> AddOrderItems(HotelModel modelObj);

        Task<HotelModel> getOrderDetailsByCustId(int custId);

        Task<int> UpdateOrderItems(HotelModel modelObj);

        Task<HotelModel> ViewOrderDetailsById(int custId);

        Task<int> DeleteOrderItem(int custId);
    }
}
