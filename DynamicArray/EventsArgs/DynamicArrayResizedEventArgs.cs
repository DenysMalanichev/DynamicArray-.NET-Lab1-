namespace MyCollection.EventsArgs;

public class DynamicArrayResizedEventArgs : EventArgs
{
    public int OldCapacity { get; private set; }
    public int NewCapacity { get; private set; }

    public DynamicArrayResizedEventArgs(int oldCapacity, int newCapacity)
    {
        OldCapacity = oldCapacity;
        NewCapacity = newCapacity;
    }
}