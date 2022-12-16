public class PatientCredential
{
    public int? ID { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public BloodType Blood { get; set; }

    public enum BloodType{
        Ap,
        Bp,
        ABp,
        Zp,
        An,
        Bn,
        ABn,
        Zn
    }
    
    
}