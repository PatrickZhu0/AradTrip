using System;
using System.Collections.Generic;

namespace TMEngine.Runtime.Unity
{
	// Token: 0x0200472A RID: 18218
	public static class TMModuleComponentManager
	{
		// Token: 0x1700223E RID: 8766
		// (get) Token: 0x0601A295 RID: 107157 RVA: 0x0082133F File Offset: 0x0081F73F
		public static string Version
		{
			get
			{
				return "1.0.0";
			}
		}

		// Token: 0x0601A296 RID: 107158 RVA: 0x00821346 File Offset: 0x0081F746
		public static T GetComponent<T>() where T : TMModuleComponent
		{
			return TMModuleComponentManager._GetComponent(typeof(T)) as T;
		}

		// Token: 0x0601A297 RID: 107159 RVA: 0x00821364 File Offset: 0x0081F764
		private static TMModuleComponent _GetComponent(Type type)
		{
			for (LinkedListNode<TMModuleComponent> linkedListNode = TMModuleComponentManager.s_ModuleComponentList.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				if (linkedListNode.Value.GetType() == type)
				{
					return linkedListNode.Value;
				}
			}
			return null;
		}

		// Token: 0x0601A298 RID: 107160 RVA: 0x008213A8 File Offset: 0x0081F7A8
		internal static void RegisterComponent(TMModuleComponent component)
		{
			if (null == component)
			{
				TMDebug.AssertFailed("Module component can not be null!");
				return;
			}
			Type type = component.GetType();
			for (LinkedListNode<TMModuleComponent> linkedListNode = TMModuleComponentManager.s_ModuleComponentList.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				if (linkedListNode.Value.GetType() == type)
				{
					TMDebug.LogWarningFormat("Module component type '{0}' is already exist!", new object[]
					{
						type.FullName
					});
					return;
				}
			}
			TMModuleComponentManager.s_ModuleComponentList.AddLast(component);
		}

		// Token: 0x0401261D RID: 75293
		private const string CONST_UNITY_FRAMEWORK_VERSION = "1.0.0";

		// Token: 0x0401261E RID: 75294
		private static readonly LinkedList<TMModuleComponent> s_ModuleComponentList = new LinkedList<TMModuleComponent>();
	}
}
