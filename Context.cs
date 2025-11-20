/* Context class to hold all context relevant to a session.
 */

namespace SeaTurtleSavior;

class Context
{
    Space current;
    bool done = false;
    private int playerX = 4; //Center af 9x9 grid/map
    private int playerY = 4;


    public Context(Space node)
    {
        current = node;
    }

    public Space GetCurrent()
    {
        return current;
    }

    public int GetPlayerX()
    {
        return playerX;
    }
    public int GetPlayerY()
    {
        return playerY;
    }

    public void ResetPlayerPosition()
    {
        playerX = 4;
        playerY = 4;
    }

    public bool MovePlayer(string direction)
    {
        int newX = playerX;
        int newY = playerY;
        switch (direction.ToLower())
        {
            case "up":
                newY--;
                break;
            case "down":
                newY++;
                break;
            case "left":
                newX--;
                break;
            case "right":
                newX++;
                break;
        }

        if (newX >= 0 && newX < 9 && newY >= 0 && newY < 9)
        {
            playerX = newX;
            playerY = newY;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Transition(string direction)
    {
        Space next = current.FollowEdge(direction);
        if (next == null)
        {
            Console.WriteLine("You are confused, and walk in a circle looking for '" + direction + "'. In the end you give up 😩");
        }
        else
        {
            current.Goodbye();
            current = next;
            ResetPlayerPosition(); // Reset player to center when changing spaces
            current.Welcome(this,false);
        }
    }

    public void Redraw()
    {
        current.Welcome(this, true);
    }

    public void SetDone(bool isDone)
    {
        this.done = isDone;
    }

    public bool GetDone()
    {
        return done;
    }
}