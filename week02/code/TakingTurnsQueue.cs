/// <summary>
/// This queue is circular. When people are added via AddPerson, they are added to the 
/// back of the queue (per FIFO rules). When GetNextPerson is called, the next person
/// in the queue is returned and then they are placed back into the queue unless they
/// have no turns left. If a person has an infinite number of turns (turns ≤ 0), they 
/// will always be placed back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless they have no more turns left.
    /// A turns value of 0 or less means the person has an infinite number of turns.
    /// An exception is thrown if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        if (person.Turns > 0)
        {
            person.Turns--;  // ✅ Fix: Ensure turns are decremented correctly
        }

        // ✅ Fix: Ensure that people with infinite turns (<= 0) are always re-added
        if (person.Turns > 0 || person.Turns <= 0)
        {
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
