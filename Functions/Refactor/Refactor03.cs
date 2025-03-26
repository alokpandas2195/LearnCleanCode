public class EmployeeDatabase 
{
    private readonly IDbConnection _db;

    public EmployeeDatabase(IDbConnection dbConnection) 
    {
        _db = dbConnection;
    }

    public Employee GetEmployee(int id) 
    {
        Employee employee =  _db.QueryFirstOrDefault<Employee>(
            "SELECT * FROM Employees WHERE Id = @Id", 
            new { Id = id });

        return employee;
    }

    public void SaveEmployee(Employee emp) 
    {
        _db.Execute(
            "UPDATE Employees SET Name = @Name WHERE Id = @Id", 
            new { emp.Name, emp.Id });
    }

    public void DeleteEmployee(int id) 
    {
        _db.Execute(
            "DELETE FROM Employees WHERE Id = @Id", 
            new { Id = id });
    }
}

public class EmployeeService 
{
    private const int _minEmployeeIdLimit = 50;
    private const int _chairmanId = 1;
    private const int _maxEmployeeNameLength = 150;
    private readonly EmployeeDatabase _repo;    

    public EmployeeService(EmployeeDatabase repo) 
    {
        _repo = repo;
    }

    public Employee GetEmployee(int id) 
    {        
         if (id < _minEmployeeIdLimit)
            throw new InvalidDataException("Employee ID starts from 50 , 1 to 49 is reserved for promoters , investors etc . Data cant be shared in HRMS due to Security issues ");

        return _repo.GetEmployee(id);
    }

    public void UpdateEmployee(Employee emp) 
    {
        if (emp.Name.Length > _maxEmployeeNameLength)
            throw new InvalidDataException("Name too long");

        _repo.SaveEmployee(emp);
    }

    public void RemoveEmployee(int id) 
    {
         if (emp.ID == _chairmanId)
            throw new InvalidDataException("Chariman cant be removed ");

        _repo.DeleteEmployee(id);
    }
}