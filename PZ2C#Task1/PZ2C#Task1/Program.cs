using System;

public class TemperatureSensor
{
    public delegate void TemperatureChangedHandler(int newTemperature);

    public event TemperatureChangedHandler OnTemperatureChanged;

    private int _currentTemperature;

    public void SetTemperature(int temperature)
    {
        Console.WriteLine($"\n--- Датчик: Температура змінилася до {temperature}°C ---");
        _currentTemperature = temperature;

        OnTemperatureChanged?.Invoke(_currentTemperature);
    }
}
public class Display
{
    public void Update(int temp) => Console.WriteLine($"[Display] Поточна температура: {temp}°C");
}
public class AirConditioner
{
    public void Update(int temp)
    {
        if (temp < 17)
            Console.WriteLine("[AirConditioner] Режим: Обігрів увімкнено");
        else if (temp > 25)
            Console.WriteLine("[AirConditioner] Режим: Охолодження увімкнено");
        else
            Console.WriteLine("[AirConditioner] Режим: Вимкнено");
    }
}
public class SecuritySystem
{
    public void Update(int temp)
    {
        if (temp > 40)
            Console.WriteLine("[SecuritySystem] КРИТИЧНО: Попередження про перегрів!");
        else if (temp < 5)
            Console.WriteLine("[SecuritySystem] УВАГА: Ризик замерзання систем!");
    }
}
class Program
{
    static void Main()
    {
        TemperatureSensor sensor = new TemperatureSensor();

        Display display = new Display();
        AirConditioner ac = new AirConditioner();
        SecuritySystem security = new SecuritySystem();

        sensor.OnTemperatureChanged += display.Update;
        sensor.OnTemperatureChanged += ac.Update;
        sensor.OnTemperatureChanged += security.Update;

        sensor.SetTemperature(20); 
        sensor.SetTemperature(10); 
        sensor.SetTemperature(30); 
        sensor.SetTemperature(45); 
        sensor.SetTemperature(2); 
    }
}