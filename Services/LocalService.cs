using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Restaurant.Models;

namespace Restaurant.Services
{
  public class LocalService
  {
    private static List<Local> locals = new List<Local>();
    private static int Count = 1;
    static LocalService()
    {
    }
    public List<Local> GetAll()
    {
      return locals;
    }
    public Local GetById(int id)
    {
      return locals.Where(local => local.Id == id).FirstOrDefault();
    }
    public Local Create(Local local)
    {
      local.Id = Count++;
      Debug.WriteLine(local.ToString());
      locals.Add(local);
      return local;
    }
    public void Update(int id, Local local)
    {
      Local found = locals.Where(n => n.Id == id).FirstOrDefault();
      found.Address = local.Address;
      found.NrOfTables = local.NrOfTables;
    }
    public void Delete(int id)
    {
      locals.RemoveAll(n => n.Id == id);
    }
  }
}