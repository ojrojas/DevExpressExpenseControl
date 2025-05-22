namespace ExpenseControl.Services.Identity.Services;

public interface ICompanyService {
    ValueTask<GetCompanyResponse> GetCompanyAsync(GetCompanyRequest request, CancellationToken cancellationToken);
}