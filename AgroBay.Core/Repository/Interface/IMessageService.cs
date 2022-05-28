using AgroBay.Core.Model;

namespace AgroBay.Core.Repository.Interface
{
  public interface IMessageRepository
  {
    Message Add(Message message);
    Message Delete(Message message);
    Message Edit(Message message);
    Message Get(int id);
    IEnumerable<Message> GetAll();
  }
}