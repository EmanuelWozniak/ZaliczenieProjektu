using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moto.Models
{
    public class MotoManager : IMotoManager
    {
        MotoDBContext motoDB = new MotoDBContext();

        public void AddToDb(Motors motor)
        {
            motoDB.Motors.Add(motor);
            motoDB.SaveChanges();
        }

        public void DeleteFromDb(int id)
        {
            Motors motor = motoDB.Motors.Find(id);
            motoDB.Motors.Remove(motor);
            motoDB.SaveChanges();
        }

        public void EditToDb(Motors motor)
        {
            Motors oldMotor = GetFromDb((int)motor.IdMoto);
            oldMotor.Name = motor.Name;
            oldMotor.Description = motor.Description;
            oldMotor.Value = motor.Value;
            oldMotor.Status = motor.Status;
            motoDB.SaveChanges();
        }

        public Motors GetFromDb(int id)
        {
            return motoDB.Motors.FirstOrDefault(x => x.IdMoto == id);
        }

        public List<Motors> ListFromDb()
        {
            return motoDB.Motors.ToList();
        }

        public void Sold(int id)
        {
            Motors motor = motoDB.Motors.Find(id);
            motor.Status = 0;
            motoDB.SaveChanges();
        }

        public void AddOrder(Orders order)
        {
            Sold((int)order.IdMoto);
            motoDB.Orders.Add(order);
            motoDB.SaveChanges();

        }
    }
}
