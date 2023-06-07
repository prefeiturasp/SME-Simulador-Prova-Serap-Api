namespace SME.Simulador.Prova.Serap.Infra;

public static class UtilDataHora
{
    public static DateTime ObterDataHoraAtualBrasiliaUtc()
    {
        var timeUtc = DateTime.UtcNow;            
        var brasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        var today = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, brasilia);
        return DateTime.SpecifyKind(today, DateTimeKind.Utc);            
    }    
}