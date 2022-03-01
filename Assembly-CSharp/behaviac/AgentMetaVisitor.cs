using System;
using System.Collections.Generic;
using System.Reflection;

namespace behaviac
{
	// Token: 0x02004809 RID: 18441
	public class AgentMetaVisitor
	{
		// Token: 0x0601A7F8 RID: 108536 RVA: 0x008345DC File Offset: 0x008329DC
		public static object GetProperty(Agent agent, string property)
		{
			Type type = agent.GetType();
			string key = type.FullName + property;
			if (AgentMetaVisitor._fields.ContainsKey(key))
			{
				return AgentMetaVisitor._fields[key].GetValue(agent);
			}
			if (AgentMetaVisitor._properties.ContainsKey(key))
			{
				return AgentMetaVisitor._properties[key].GetValue(agent, null);
			}
			while (type != typeof(object))
			{
				FieldInfo field = type.GetField(property, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				if (field != null)
				{
					AgentMetaVisitor._fields[key] = field;
					return field.GetValue(agent);
				}
				PropertyInfo property2 = type.GetProperty(property, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				if (property2 != null)
				{
					AgentMetaVisitor._properties[key] = property2;
					return property2.GetValue(agent, null);
				}
				type = type.BaseType;
			}
			return null;
		}

		// Token: 0x0601A7F9 RID: 108537 RVA: 0x008346A8 File Offset: 0x00832AA8
		public static void SetProperty(Agent agent, string property, object value)
		{
			Type type = agent.GetType();
			string key = type.FullName + property;
			if (AgentMetaVisitor._fields.ContainsKey(key))
			{
				AgentMetaVisitor._fields[key].SetValue(agent, value);
				return;
			}
			if (AgentMetaVisitor._properties.ContainsKey(key))
			{
				AgentMetaVisitor._properties[key].SetValue(agent, value, null);
				return;
			}
			while (type != typeof(object))
			{
				FieldInfo field = type.GetField(property, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				if (field != null)
				{
					AgentMetaVisitor._fields[key] = field;
					field.SetValue(agent, value);
					return;
				}
				PropertyInfo property2 = type.GetProperty(property, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				if (property2 != null)
				{
					AgentMetaVisitor._properties[key] = property2;
					property2.SetValue(agent, value, null);
					return;
				}
				type = type.BaseType;
			}
		}

		// Token: 0x0601A7FA RID: 108538 RVA: 0x00834778 File Offset: 0x00832B78
		public static object ExecuteMethod(Agent agent, string method, object[] args)
		{
			Type type = agent.GetType();
			string key = type.FullName + method;
			if (AgentMetaVisitor._methods.ContainsKey(key))
			{
				return AgentMetaVisitor._methods[key].Invoke(agent, args);
			}
			while (type != typeof(object))
			{
				MethodInfo method2 = type.GetMethod(method, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				if (method2 != null)
				{
					AgentMetaVisitor._methods[key] = method2;
					return method2.Invoke(agent, args);
				}
				type = type.BaseType;
			}
			return null;
		}

		// Token: 0x04012928 RID: 76072
		private static Dictionary<string, FieldInfo> _fields = new Dictionary<string, FieldInfo>();

		// Token: 0x04012929 RID: 76073
		private static Dictionary<string, PropertyInfo> _properties = new Dictionary<string, PropertyInfo>();

		// Token: 0x0401292A RID: 76074
		private static Dictionary<string, MethodInfo> _methods = new Dictionary<string, MethodInfo>();
	}
}
