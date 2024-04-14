using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class ViewModelTest
    {
        public Person Person { get; set; }=new Person();
        public int A;
        public int sum()
        { return 1; }
        public ViewModelTest() { }  
    }
}
