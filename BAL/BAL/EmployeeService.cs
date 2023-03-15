using DAL;
using DAL.UnitofWork;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   public class EmployeeService
    {
        private UnitofWork unitOfWork = new UnitofWork();
        public IList<EmployeeViewModel> GetAllEmployee()
        {
            var model = unitOfWork.EmployeeRepository.GetAll();
            List<EmployeeViewModel> viewModel = new List<EmployeeViewModel>();

            for (var i = 0; i < model.Count; i++)
            {
                EmployeeViewModel p = new EmployeeViewModel
                {
                    Employee_ID = model[i].Employee_ID,
                    Empolyee_Name = model[i].Empolyee_Name,
                    
                };
                viewModel.Add(p);
            }

            

            return viewModel;
        }


        public IList<EmployeeViewModel> GetEmployeeById(int id)

        {
            var model = unitOfWork.EmployeeRepository.GetAll().Where(s => s.Employee_ID == id);


            List<EmployeeViewModel> viewModel = new List<EmployeeViewModel>();

            foreach (Empolyee emp in model)
            {
                //var depModel = unitOfWork.DepartmentRepository.GetById(emp.Dept);
                EmployeeViewModel p = new EmployeeViewModel
                {
                    Employee_ID = emp.Employee_ID,
                    Empolyee_Name = emp.Empolyee_Name,
                    Employee_Address = emp.Employee_Address,
                    Employee_Phone = emp.Employee_Phone
                   
                };
                viewModel.Add(p);
            }
            return viewModel;
        }

        public void DeleteEmployeeById(int id)

        {
            var model = unitOfWork.EmployeeRepository.GetById(id)
;
            unitOfWork.EmployeeRepository.Delete(model);
            unitOfWork.Save();
        }
        //public void Add (Empolyee empolyee)
        //{
        //      unitOfWork.EmployeeRepository.Add(empolyee);
        //}
        public void Insert(EmployeeViewModel employee)
        {
            Empolyee emp = new Empolyee
            {
                Empolyee_Name = employee.Empolyee_Name,
                Employee_Phone = employee.Employee_Phone,
                Employee_Address = employee.Employee_Address

            };

            unitOfWork.EmployeeRepository.Insert(emp);
            unitOfWork.Save();
           
        }

    }
   
}
