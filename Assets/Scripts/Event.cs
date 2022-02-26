using System;
using System.Linq;


public class Event
{
    private event Action Action = delegate { };

    public void Invoke()
    {
        Action.Invoke();
    }

    public void AddListener(Action action)
    {
        if (!this.Action.GetInvocationList().Contains(action))
        {
            this.Action += action;
        }

    }

    public void RemoveListener(Action action)
    {
        this.Action -= action;
    }

}

public class Event<T>
{
    private event Action<T> Action = delegate { };

    public void Invoke(T param)
    {
        Action.Invoke(param);
    }

    public void AddListener(Action<T> action)
    {
        if (!this.Action.GetInvocationList().Contains(action))
        {
            this.Action += action;
        }
    }

    public void RemoveListenr(Action<T> action)
    {
        this.Action -= action;
    }
}
