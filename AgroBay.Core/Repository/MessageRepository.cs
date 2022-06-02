using AgroBay.Core.Data;
using AgroBay.Core.Model;
using AgroBay.Core.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Repository
{
  public class MessageRepository : IMessageRepository
  {
    private AgroBayDbContext _db;
    public MessageRepository(AgroBayDbContext message)
    {
      _db = message;
    }


    public Message Get(int id)
    {
      var message = _db.Messages.First(c => c.Id == id);
      _db.Entry<Message>(message).State = EntityState.Detached;
      return message;
    }

    public IEnumerable<Message> GetAll()
    {
      var message = _db.Messages;
      _db.Entry<IEnumerable<Message>>(message).State = EntityState.Detached;
      return message;
    }

    public Message Add(Message message)
    {
      _db.Messages.Add(message);
      _db.SaveChanges();
      return message;
    }

    public Message Edit(Message message)
    {
      _db.Messages.Update(message);
      _db.SaveChanges();
      return message;
    }

    public Message Delete(Message message)
    {
      _db.Messages.Remove(message);
      _db.SaveChanges();
      return message;
    }
  }
}
