

public interface IFuel
{
    bool HasFuel { get; }
    void CombustFuel();
    void CombustFuel(float speed);
    void RefillFuel();
    void RefillFuel(float speed);
}
