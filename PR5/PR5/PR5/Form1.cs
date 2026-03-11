using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PR5
{
    public partial class Form1 : Form
    {
        private StringBuilder input = new StringBuilder();
        private double ans = 0;
        private bool newCalc = false;

        public Form1()
        {
            InitializeComponent();
            txtDisplay.Text = "0";
        }

        // Общий обработчик для всех кнопок
        private void Button_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var text = btn.Text;

            if (newCalc)
            {
                input.Clear();
                newCalc = false;
            }

            if (text == "C")
                input.Clear();
            else if (text == "del" && input.Length > 0)
                input.Length--;
            else if (text == "(-)")
                input.Append("-");
            else if (text == "=")
            {
                Calculate();
                return;
            }
            else if (text == "Ans")
                input.Append("Ans");
            else if (text == "π")
                input.Append("π");
            else if (text == "e")
                input.Append("e");
            else if (text == "Sum")
                input.Append("+");
            else if ("sincostanloglnrootAbs".Contains(text))
                input.Append(text.ToLower() + "(");
            else if ("+-*/^".Contains(text))
                input.Append(" " + text + " ");
            else if ("()".Contains(text))
                input.Append(text);
            else
                input.Append(text);

            txtDisplay.Text = input.Length > 0 ? input.ToString() : "0";
        }

        private void Calculate()
        {
            try
            {
                string expr = input.ToString();
                expr = expr.Replace("π", Math.PI.ToString())
                           .Replace("e", Math.E.ToString())
                           .Replace("Ans", ans.ToString());

                expr = ProcessFunctions(expr);
                ans = EvaluateBasic(expr);
                txtDisplay.Text = FormatResult(ans);
                input.Clear();
                input.Append(ans.ToString());
                newCalc = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FormatResult(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                return "Ошибка";

            string result = value.ToString("G10");
            if (result.Contains("."))
                result = result.TrimEnd('0').TrimEnd('.');

            if (Math.Abs(value) > 1e10 || (Math.Abs(value) < 1e-10 && value != 0))
                return value.ToString("E6");

            return result;
        }

        private string ProcessFunctions(string expr)
        {
            var funcs = new Dictionary<string, Func<double, double>>
            {
                {"sin", x => Math.Sin(x * Math.PI / 180)},
                {"cos", x => Math.Cos(x * Math.PI / 180)},
                {"tan", x => Math.Tan(x * Math.PI / 180)},
                {"log", x => Math.Log10(x)},
                {"ln", x => Math.Log(x)},
                {"root", x => Math.Sqrt(x)},
                {"abs", x => Math.Abs(x)}
            };

            foreach (var func in funcs)
            {
                while (true)
                {
                    int idx = expr.IndexOf(func.Key + "(");
                    if (idx == -1) break;

                    int start = idx + func.Key.Length + 1;
                    int depth = 1;
                    int end = start;

                    while (end < expr.Length && depth > 0)
                    {
                        if (expr[end] == '(') depth++;
                        if (expr[end] == ')') depth--;
                        end++;
                    }

                    if (depth == 0)
                    {
                        string arg = expr.Substring(start, end - start - 1);
                        double argVal = EvaluateBasic(arg);
                        double result = func.Value(argVal);
                        expr = expr.Remove(idx, end - idx).Insert(idx, result.ToString());
                    }
                    else break;
                }
            }

            return expr;
        }

        private double EvaluateBasic(string expr)
        {
            expr = expr.Replace(" ", "");

            if (string.IsNullOrEmpty(expr))
                return 0;

            Stack<double> values = new Stack<double>();
            Stack<char> ops = new Stack<char>();

            for (int i = 0; i < expr.Length; i++)
            {
                char c = expr[i];

                if (char.IsDigit(c) || c == '.')
                {
                    string num = "";
                    while (i < expr.Length && (char.IsDigit(expr[i]) || expr[i] == '.'))
                        num += expr[i++];
                    i--;

                    if (double.TryParse(num, out double val))
                        values.Push(val);
                }
                else if (c == '(')
                {
                    ops.Push(c);
                }
                else if (c == ')')
                {
                    while (ops.Count > 0 && ops.Peek() != '(')
                        values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
                    ops.Pop();
                }
                else if (c == '-' && (i == 0 || expr[i - 1] == '(' || "+-*/^".Contains(expr[i - 1].ToString())))
                {
                    // Унарный минус
                    i++;
                    string num = "-";
                    while (i < expr.Length && (char.IsDigit(expr[i]) || expr[i] == '.'))
                        num += expr[i++];
                    i--;

                    if (double.TryParse(num, out double val))
                        values.Push(val);
                }
                else if ("+-*/^".Contains(c.ToString()))
                {
                    while (ops.Count > 0 && Precedence(c) <= Precedence(ops.Peek()))
                        values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
                    ops.Push(c);
                }
            }

            while (ops.Count > 0)
                values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));

            return values.Pop();
        }

        private int Precedence(char op)
        {
            if (op == '^') return 3;
            if (op == '*' || op == '/') return 2;
            return 1;
        }

        private double ApplyOp(char op, double b, double a)
        {
            switch (op)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/':
                    if (b == 0) throw new DivideByZeroException("Деление на ноль");
                    return a / b;
                case '^': return Math.Pow(a, b);
                default: throw new ArgumentException("Неизвестный оператор");
            }
        }
    }
}
