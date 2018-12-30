using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Operations_With_Lambda_Operator
{
    public static class ArithmeticOp
    {
        public static ArrayList ArithmeticOperation(double num1, double num2, ArithOp oper)
        {
            ArrayList result = new ArrayList();
            result.Add(false);
            result.Add(0);
            bool isEverythingOk = true;

            Arithmetic operation = null;

            switch (oper)
            {
                case ArithOp.Add:
                    operation = (x, y) => { return x + y; };
                    break;
                case ArithOp.Sub:
                    operation = (x, y) => { return x - y; };
                    break;
                case ArithOp.Mul:
                    operation = (x, y) => { return x * y; };
                    break;
                case ArithOp.Div:
                    operation = (x, y) =>
                    {
                        if (y != 0)
                        {
                            return x / y;
                        }
                        else
                        {
                            isEverythingOk = false;
                            return default(double);
                        }
                    };
                    break;
            }

            if (operation != null)
            {
                result[1] = operation(num1, num2);
                result[0] = isEverythingOk;
            }

            return result;
        }
    }
}
