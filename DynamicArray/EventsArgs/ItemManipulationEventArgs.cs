namespace MyCollection.EventsArgs;

public class ItemManipulationEventArgs<T> : EventArgs
{
    public T Item { get; private set; }
    public int Index { get; private set; }

    public ItemManipulationEventArgs(T item, int index)
    {
        Item = item;
        Index = index;
    }
}