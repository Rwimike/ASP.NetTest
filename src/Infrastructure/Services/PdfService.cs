namespace Infrastructure.Services;

public interface IPdfService
{
    Task<byte[]> GenerateEmployeePdfAsync(EmployeeDTO employee);
}

public class PdfService : IPdfService
{
    public Task<byte[]> GenerateEmployeePdfAsync(EmployeeDTO employee)
    {
        // HTML simple para examen
        var html = $@"
            <html>
            <head><title>Hoja de Vida - {employee.FirstNames}</title></head>
            <body>
                <h1>Hoja de Vida</h1>
                <h2>{employee.FirstNames} {employee.LastNames}</h2>
                
                <h3>Datos Personales</h3>
                <p><strong>Documento:</strong> {employee.Document}</p>
                <p><strong>Email:</strong> {employee.Email}</p>
                <p><strong>Teléfono:</strong> {employee.PhoneNumber}</p>
                
                <h3>Información Laboral</h3>
                <p><strong>Cargo:</strong> {employee.PositionName}</p>
                <p><strong>Salario:</strong> {employee.Salary:C}</p>
                <p><strong>Fecha Ingreso:</strong> {employee.HireDate:dd/MM/yyyy}</p>
                <p><strong>Estado:</strong> {employee.StatusName}</p>
                
                <p>Generado el: {DateTime.Now:dd/MM/yyyy HH:mm}</p>
            </body>
            </html>
        ";
        
        var bytes = Encoding.UTF8.GetBytes(html);
        return Task.FromResult(bytes);
    }
}