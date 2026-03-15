using System;

public class Player
{
    public event Action<int, int> OnDamageReceived;

    public int Health { get; private set; } = 100;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;

        Console.WriteLine($"\n>>> ГРАВЕЦЬ: Отримано {damage} урону. Залишилось HP: {Health} <<<");

        OnDamageReceived?.Invoke(damage, Health);
    }
}
public class UIHealthBar
{
    public void OnNotify(int damage, int currentHP) =>
        Console.WriteLine($"[UI] Оновлення HP Bar: {currentHP}%");
}

public class SoundSystem
{
    public void OnNotify(int damage, int currentHP)
    {
        Console.WriteLine("[Sound] Відтворення звуку: 'Ouch!'");
        if (currentHP > 0 && currentHP <= 20)
            Console.WriteLine("[Sound] КРИТИЧНИЙ СТАН: Відтворення тривожного серцебиття!");
    }
}

public class AchievementSystem
{
    private bool _halfHealthReached = false;
    private bool _firstDeathReached = false;

    public void OnNotify(int damage, int currentHP)
    {
        if (currentHP <= 50 && !_halfHealthReached)
        {
            Console.WriteLine("[Achievement] ОТРИМАНО: 'Half Health' (Здоров'я наполовину!)");
            _halfHealthReached = true;
        }
        if (currentHP <= 0 && !_firstDeathReached)
        {
            Console.WriteLine("[Achievement] ОТРИМАНО: 'First Death' (Ласкаво просимо в пекло!)");
            _firstDeathReached = true;
        }
    }
}

public class GameLogger
{
    public void OnNotify(int damage, int currentHP) =>
        Console.WriteLine($"[Logger] Запис: Урон -{damage}, Поточне HP: {currentHP}");
}
class Program
{
    static void Main()
    {
        Player player = new Player();

        UIHealthBar ui = new UIHealthBar();
        SoundSystem sound = new SoundSystem();
        AchievementSystem achievements = new AchievementSystem();
        GameLogger logger = new GameLogger();

        player.OnDamageReceived += ui.OnNotify;
        player.OnDamageReceived += sound.OnNotify;
        player.OnDamageReceived += achievements.OnNotify;
        player.OnDamageReceived += logger.OnNotify;

        player.TakeDamage(20); 
        player.TakeDamage(35);
        player.TakeDamage(30); 
        player.TakeDamage(20); 
    }
}