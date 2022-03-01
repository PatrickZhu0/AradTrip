using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

// Token: 0x02000158 RID: 344
public class ObjectDumper
{
	// Token: 0x060009EC RID: 2540 RVA: 0x00034314 File Offset: 0x00032714
	private ObjectDumper(int indentSize)
	{
		this._indentSize = indentSize;
		this._stringBuilder = new StringBuilder();
		this._hashListOfFoundElements = new List<int>();
	}

	// Token: 0x060009ED RID: 2541 RVA: 0x00034339 File Offset: 0x00032739
	public static string Dump(object element)
	{
		return "��\udabe\udeba���ܷ������û����д���ע��";
	}

	// Token: 0x060009EE RID: 2542 RVA: 0x00034340 File Offset: 0x00032740
	public static string Dump(object element, int indentSize)
	{
		ObjectDumper objectDumper = new ObjectDumper(indentSize);
		return objectDumper.DumpElement(element);
	}

	// Token: 0x060009EF RID: 2543 RVA: 0x0003435C File Offset: 0x0003275C
	private string DumpElement(object element)
	{
		if (element == null || element is ValueType || element is string)
		{
			this.Write(this.FormatValue(element), new object[0]);
		}
		else
		{
			Type type = element.GetType();
			if (!typeof(IEnumerable).IsAssignableFrom(type))
			{
				this.Write("[{0}]", new object[]
				{
					type.FullName
				});
				this._hashListOfFoundElements.Add(element.GetHashCode());
				this._level++;
			}
			IEnumerable enumerable = element as IEnumerable;
			if (enumerable != null)
			{
				IEnumerator enumerator = enumerable.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						if (obj is IEnumerable && !(obj is string))
						{
							this._level++;
							this.DumpElement(obj);
							this._level--;
						}
						else if (!this.AlreadyTouched(obj))
						{
							this.DumpElement(obj);
						}
						else
						{
							this.Write("[{0}] <-- bidirectional reference found", new object[]
							{
								obj.GetType().FullName
							});
						}
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			else
			{
				MemberInfo[] members = element.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Public);
				foreach (MemberInfo memberInfo in members)
				{
					FieldInfo fieldInfo = memberInfo as FieldInfo;
					PropertyInfo propertyInfo = memberInfo as PropertyInfo;
					if (fieldInfo != null || propertyInfo != null)
					{
						Type type2 = (fieldInfo == null) ? propertyInfo.PropertyType : fieldInfo.FieldType;
						object obj2 = (fieldInfo == null) ? propertyInfo.GetValue(element, null) : fieldInfo.GetValue(element);
						if (type2.IsValueType || type2 == typeof(string))
						{
							this.Write("{0}: {1}", new object[]
							{
								memberInfo.Name,
								this.FormatValue(obj2)
							});
						}
						else
						{
							bool flag = typeof(IEnumerable).IsAssignableFrom(type2);
							this.Write("{0}: {1}", new object[]
							{
								memberInfo.Name,
								(!flag) ? "[ ]" : "..."
							});
							bool flag2 = !flag && this.AlreadyTouched(obj2);
							this._level++;
							if (!flag2)
							{
								this.DumpElement(obj2);
							}
							else
							{
								this.Write("[{0}] <-- bidirectional reference found", new object[]
								{
									obj2.GetType().FullName
								});
							}
							this._level--;
						}
					}
				}
			}
			if (!typeof(IEnumerable).IsAssignableFrom(type))
			{
				this._level--;
			}
		}
		return this._stringBuilder.ToString();
	}

	// Token: 0x060009F0 RID: 2544 RVA: 0x0003467C File Offset: 0x00032A7C
	private bool AlreadyTouched(object value)
	{
		if (value == null)
		{
			return false;
		}
		int hashCode = value.GetHashCode();
		for (int i = 0; i < this._hashListOfFoundElements.Count; i++)
		{
			if (this._hashListOfFoundElements[i] == hashCode)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060009F1 RID: 2545 RVA: 0x000346CC File Offset: 0x00032ACC
	private void Write(string value, params object[] args)
	{
		string str = new string(' ', this._level * this._indentSize);
		if (args != null)
		{
			value = string.Format(value, args);
		}
		this._stringBuilder.AppendLine(str + value);
	}

	// Token: 0x060009F2 RID: 2546 RVA: 0x00034710 File Offset: 0x00032B10
	private string FormatValue(object o)
	{
		if (o == null)
		{
			return "null";
		}
		if (o is DateTime)
		{
			return ((DateTime)o).ToShortDateString();
		}
		if (o is string)
		{
			return string.Format("\"{0}\"", o);
		}
		if (o is char && (char)o == '\0')
		{
			return string.Empty;
		}
		if (o is ValueType)
		{
			return o.ToString();
		}
		if (o is IEnumerable)
		{
			return "...";
		}
		return "[ ]";
	}

	// Token: 0x04000767 RID: 1895
	private int _level;

	// Token: 0x04000768 RID: 1896
	private readonly int _indentSize;

	// Token: 0x04000769 RID: 1897
	private readonly StringBuilder _stringBuilder;

	// Token: 0x0400076A RID: 1898
	private readonly List<int> _hashListOfFoundElements;

	// Token: 0x0400076B RID: 1899
	private const string dumpTips = "��\udabe\udeba���ܷ������û����д���ע��";
}
