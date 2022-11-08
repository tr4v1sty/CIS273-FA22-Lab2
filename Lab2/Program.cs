using System.Linq;
using System.Linq.Expressions;

namespace Lab2;
public class Program
{
    public static void Main(string[] args)
    {
        IsBalanced("{ ( < > ) }");  // true
        IsBalanced("<> {(})");      // false
        IsBalanced("List<int> list = new List<int>();"); //should be true
    }

    public static bool IsBalanced(string s)
    {
        Stack<char> stack = new Stack<char>();

        // iterate over all chars in string
        foreach(char c in s)
        {


            // if char is an open thing, push it
            if (c == '<' || c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }

            // if char is a close thing,
            // compare it to top of stack;
            else if (c == '>' || c == ')' || c == '}' || c == ']')
            {
                char top;
                bool result = stack.TryPeek(out top);
                // handle result == false

                // if they match, pop()
                if (Matches(c, top))
                {
                    stack.Pop();
                }
                // else, return false
                else
                {
                    return false;
                }

            }
            
        }
        

        // if stack is empty, return true
        if( stack.Count == 0)
        {
            return true;
        }
        return false;

    }
    // im an idiot i forgot < and >
    private static bool Matches(char closing, char opening)
    {
        if (opening == '(' && closing == ')')
            return true;
        else if (opening == '{' && closing == '}')
            return true;
        else if (opening == '<' && closing == '>')
            return true;
        else if (opening == '[' && closing == ']')
            return true;
        else
            return false;
    }


    public static double? Evaluate(string s)
    {
        //return null if empty else run
        if (string.IsNullOrEmpty(s))
        {
            return null;
        }
        // new stack as a double
        var stack = new Stack<double>();
        // parse string into tokens
        string[] tokens = s.Split();
        // foreach token
        foreach (var c in tokens)
        {
            //switch: if var c is found in a case below, run case. If its an operator pop twice, return result,then break.
            // else goes to default and pushes the var c (integer) as a double.
            // after all variables have gone through: peek and return that variable
            //switches and cases explanations found from microsoft.learn W3schools and geeks4geeks

            switch (c)
            {
                
                case "+":
                    //pop 2* if its an operator
                    var plus1 = stack.Pop();
                    var plus2 = stack.Pop();
                    // find the result
                    var resultplus = plus1 + plus2;
                    //push it
                    stack.Push(resultplus);
                    break;
                    
                case "-":
                    var min1 = stack.Pop();
                    var min2 = stack.Pop();

                    var resultmin = min2 - min1;
                    stack.Push(resultmin);
                    break;
                case "*":
                    var multi1 = stack.Pop();
                    var multi2 = stack.Pop();

                    var resultmulti = multi1 * multi2;
                    stack.Push(resultmulti);
                    break;
                case "/":
                    var div1 = stack.Pop();
                    var div2 = stack.Pop();

                    var resultdiv = div2 / div1;
                    stack.Push(resultdiv);
                    break;
                    // if its a number just push
                default:
                    stack.Push(double.Parse(c));
                    break;
            }
        }
        //return stack
        return stack.Peek();
    }





    

}
       
    



