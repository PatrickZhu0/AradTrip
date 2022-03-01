using System;
using System.Collections.Generic;

namespace TMEngine.Runtime
{
	// Token: 0x02004724 RID: 18212
	public static class ModuleManager
	{
		// Token: 0x1700221F RID: 8735
		// (get) Token: 0x0601A251 RID: 107089 RVA: 0x008208AB File Offset: 0x0081ECAB
		public static string Version
		{
			get
			{
				return "1.0.0";
			}
		}

		// Token: 0x0601A252 RID: 107090 RVA: 0x008208B4 File Offset: 0x0081ECB4
		public static void Update(float elapseSeconds, float realElapseSeconds)
		{
			foreach (BaseModule baseModule in ModuleManager.sm_GameFrameworkModules)
			{
				baseModule.Update(elapseSeconds, realElapseSeconds);
			}
		}

		// Token: 0x0601A253 RID: 107091 RVA: 0x00820910 File Offset: 0x0081ED10
		public static void Shutdown()
		{
			for (LinkedListNode<BaseModule> linkedListNode = ModuleManager.sm_GameFrameworkModules.Last; linkedListNode != null; linkedListNode = linkedListNode.Previous)
			{
				linkedListNode.Value.Shutdown();
			}
			ModuleManager.sm_GameFrameworkModules.Clear();
		}

		// Token: 0x0601A254 RID: 107092 RVA: 0x00820950 File Offset: 0x0081ED50
		public static T GetModule<T>() where T : class
		{
			Type typeFromHandle = typeof(T);
			if (!typeFromHandle.IsInterface)
			{
				TMDebug.AssertFailed(string.Format("You must get module by interface, but '{0}' is not.", typeFromHandle.FullName));
				return (T)((object)null);
			}
			if (!typeFromHandle.FullName.StartsWith("TMEngine."))
			{
				TMDebug.AssertFailed(string.Format("You must get a Game Framework module, but '{0}' is not.", typeFromHandle.FullName));
				return (T)((object)null);
			}
			string text = string.Format("{0}.{1}", typeFromHandle.Namespace, typeFromHandle.Name.Substring(3));
			Type type = Type.GetType(text);
			if (type == null)
			{
				TMDebug.AssertFailed(string.Format("Can not find BaseFramework module type '{0}'.", text));
				return (T)((object)null);
			}
			return ModuleManager._GetModule(type) as T;
		}

		// Token: 0x0601A255 RID: 107093 RVA: 0x00820A18 File Offset: 0x0081EE18
		private static BaseModule _GetModule(Type moduleType)
		{
			foreach (BaseModule baseModule in ModuleManager.sm_GameFrameworkModules)
			{
				if (baseModule.GetType() == moduleType)
				{
					return baseModule;
				}
			}
			return ModuleManager._CreateModule(moduleType);
		}

		// Token: 0x0601A256 RID: 107094 RVA: 0x00820A88 File Offset: 0x0081EE88
		private static BaseModule _CreateModule(Type moduleType)
		{
			BaseModule baseModule = (BaseModule)Utility.Assembly.CreateInstance(moduleType);
			if (baseModule == null)
			{
				TMDebug.AssertFailed(string.Format("Can not create module '{0}'.", baseModule.GetType().FullName));
				return null;
			}
			LinkedListNode<BaseModule> linkedListNode;
			for (linkedListNode = ModuleManager.sm_GameFrameworkModules.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				if (baseModule.Priority > linkedListNode.Value.Priority)
				{
					break;
				}
			}
			if (linkedListNode != null)
			{
				ModuleManager.sm_GameFrameworkModules.AddBefore(linkedListNode, baseModule);
			}
			else
			{
				ModuleManager.sm_GameFrameworkModules.AddLast(baseModule);
			}
			return baseModule;
		}

		// Token: 0x040125FA RID: 75258
		private const string FrameworkVersion = "1.0.0";

		// Token: 0x040125FB RID: 75259
		private static readonly LinkedList<BaseModule> sm_GameFrameworkModules = new LinkedList<BaseModule>();
	}
}
