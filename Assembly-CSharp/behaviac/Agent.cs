using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace behaviac
{
	// Token: 0x02004752 RID: 18258
	[TypeMetaInfo]
	public class Agent
	{
		// Token: 0x0601A39D RID: 107421 RVA: 0x006D79E1 File Offset: 0x006D5DE1
		protected Agent()
		{
			this.Init();
		}

		// Token: 0x0601A39E RID: 107422 RVA: 0x006D7A04 File Offset: 0x006D5E04
		~Agent()
		{
			this.OnDestroy();
		}

		// Token: 0x0601A39F RID: 107423 RVA: 0x006D7A34 File Offset: 0x006D5E34
		public void UnLoad()
		{
			this.OnDestroy();
		}

		// Token: 0x0601A3A0 RID: 107424 RVA: 0x006D7A3C File Offset: 0x006D5E3C
		protected void Init()
		{
			this.Awake();
		}

		// Token: 0x0601A3A1 RID: 107425 RVA: 0x006D7A44 File Offset: 0x006D5E44
		private void Awake()
		{
			Agent.Init_(this.m_contextId, this, this.m_priority);
		}

		// Token: 0x0601A3A2 RID: 107426 RVA: 0x006D7A58 File Offset: 0x006D5E58
		private void OnDestroy()
		{
			Context.RemoveAgent(this);
			if (this.m_behaviorTreeTasks != null)
			{
				for (int i = 0; i < this.m_behaviorTreeTasks.Count; i++)
				{
					BehaviorTreeTask behaviorTreeTask = this.m_behaviorTreeTasks[i];
					Workspace.Instance.DestroyBehaviorTreeTask(behaviorTreeTask, this);
				}
				this.m_behaviorTreeTasks.Clear();
				this.m_behaviorTreeTasks = null;
			}
		}

		// Token: 0x17002259 RID: 8793
		// (get) Token: 0x0601A3A3 RID: 107427 RVA: 0x006D7ABD File Offset: 0x006D5EBD
		private List<BehaviorTreeTask> BehaviorTreeTasks
		{
			get
			{
				if (this.m_behaviorTreeTasks == null)
				{
					this.m_behaviorTreeTasks = new List<BehaviorTreeTask>();
				}
				return this.m_behaviorTreeTasks;
			}
		}

		// Token: 0x1700225A RID: 8794
		// (get) Token: 0x0601A3A4 RID: 107428 RVA: 0x006D7ADB File Offset: 0x006D5EDB
		private List<Agent.BehaviorTreeStackItem_t> BTStack
		{
			get
			{
				if (this.m_btStack == null)
				{
					this.m_btStack = new List<Agent.BehaviorTreeStackItem_t>();
				}
				return this.m_btStack;
			}
		}

		// Token: 0x1700225B RID: 8795
		// (get) Token: 0x0601A3A5 RID: 107429 RVA: 0x006D7AF9 File Offset: 0x006D5EF9
		// (set) Token: 0x0601A3A6 RID: 107430 RVA: 0x006D7B01 File Offset: 0x006D5F01
		public BehaviorTreeTask CurrentTreeTask
		{
			get
			{
				return this.m_currentBT;
			}
			private set
			{
				this.m_currentBT = value;
			}
		}

		// Token: 0x1700225C RID: 8796
		// (get) Token: 0x0601A3A7 RID: 107431 RVA: 0x006D7B0A File Offset: 0x006D5F0A
		// (set) Token: 0x0601A3A8 RID: 107432 RVA: 0x006D7B12 File Offset: 0x006D5F12
		public BehaviorTreeTask ExcutingTreeTask
		{
			get
			{
				return this.m_excutingTreeTask;
			}
			set
			{
				this.m_excutingTreeTask = value;
			}
		}

		// Token: 0x0601A3A9 RID: 107433 RVA: 0x006D7B1B File Offset: 0x006D5F1B
		public int GetId()
		{
			return this.m_id;
		}

		// Token: 0x0601A3AA RID: 107434 RVA: 0x006D7B23 File Offset: 0x006D5F23
		public int GetPriority()
		{
			return this.m_priority;
		}

		// Token: 0x0601A3AB RID: 107435 RVA: 0x006D7B2B File Offset: 0x006D5F2B
		public string GetClassTypeName()
		{
			return base.GetType().FullName;
		}

		// Token: 0x0601A3AC RID: 107436 RVA: 0x006D7B38 File Offset: 0x006D5F38
		public bool IsMasked()
		{
			return (this.m_idFlag & Agent.IdMask()) != 0U;
		}

		// Token: 0x0601A3AD RID: 107437 RVA: 0x006D7B4C File Offset: 0x006D5F4C
		public void SetIdFlag(uint idMask)
		{
			this.m_idFlag = idMask;
		}

		// Token: 0x0601A3AE RID: 107438 RVA: 0x006D7B58 File Offset: 0x006D5F58
		public static bool IsDerived(Agent pAgent, string agentType)
		{
			bool result = false;
			for (Type type = pAgent.GetType(); type != null; type = type.BaseType)
			{
				if (type.FullName == agentType)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x0601A3AF RID: 107439 RVA: 0x006D7B99 File Offset: 0x006D5F99
		public static void SetIdMask(uint idMask)
		{
			Agent.ms_idMask = idMask;
		}

		// Token: 0x0601A3B0 RID: 107440 RVA: 0x006D7BA1 File Offset: 0x006D5FA1
		public static uint IdMask()
		{
			return Agent.ms_idMask;
		}

		// Token: 0x0601A3B1 RID: 107441 RVA: 0x006D7BA8 File Offset: 0x006D5FA8
		public string GetName()
		{
			return this.name;
		}

		// Token: 0x0601A3B2 RID: 107442 RVA: 0x006D7BB0 File Offset: 0x006D5FB0
		public void SetName(string instanceName)
		{
			if (string.IsNullOrEmpty(instanceName))
			{
				string fullName = base.GetType().FullName;
				int num = fullName.LastIndexOf(':');
				string arg;
				if (num != -1)
				{
					arg = fullName.Substring(num + 1);
				}
				else
				{
					arg = fullName;
				}
				if (Agent.ms_agent_type_index == null)
				{
					Agent.ms_agent_type_index = new Dictionary<string, int>();
				}
				int num2;
				if (!Agent.ms_agent_type_index.ContainsKey(fullName))
				{
					num2 = 0;
					Agent.ms_agent_type_index[fullName] = 1;
				}
				else
				{
					Dictionary<string, int> dictionary;
					string key;
					int num3;
					(dictionary = Agent.ms_agent_type_index)[key = fullName] = (num3 = dictionary[key]) + 1;
					num2 = num3;
				}
				this.name += string.Format("{0}_{1}_{2}", arg, num2, this.m_id);
			}
			else
			{
				this.name = instanceName;
			}
		}

		// Token: 0x0601A3B3 RID: 107443 RVA: 0x006D7C8B File Offset: 0x006D608B
		public int GetContextId()
		{
			return this.m_contextId;
		}

		// Token: 0x0601A3B4 RID: 107444 RVA: 0x006D7C93 File Offset: 0x006D6093
		public bool IsActive()
		{
			return this.m_bActive;
		}

		// Token: 0x0601A3B5 RID: 107445 RVA: 0x006D7C9B File Offset: 0x006D609B
		public void SetActive(bool bActive)
		{
			this.m_bActive = bActive;
		}

		// Token: 0x1700225D RID: 8797
		// (get) Token: 0x0601A3B6 RID: 107446 RVA: 0x006D7CA4 File Offset: 0x006D60A4
		internal static Dictionary<string, Agent.AgentName_t> Names
		{
			get
			{
				if (Agent.ms_names == null)
				{
					Agent.ms_names = new Dictionary<string, Agent.AgentName_t>();
				}
				return Agent.ms_names;
			}
		}

		// Token: 0x0601A3B7 RID: 107447 RVA: 0x006D7CC0 File Offset: 0x006D60C0
		public static bool RegisterInstanceName<TAGENT>(string agentInstanceName, string displayName, string desc) where TAGENT : Agent
		{
			string text = agentInstanceName;
			if (string.IsNullOrEmpty(text))
			{
				text = typeof(TAGENT).FullName;
			}
			if (!Agent.Names.ContainsKey(text))
			{
				string fullName = typeof(TAGENT).FullName;
				Agent.Names[text] = new Agent.AgentName_t(text, fullName, displayName, desc);
				return true;
			}
			return false;
		}

		// Token: 0x0601A3B8 RID: 107448 RVA: 0x006D7D21 File Offset: 0x006D6121
		public static bool RegisterInstanceName<TAGENT>(string agentInstanceName) where TAGENT : Agent
		{
			return Agent.RegisterInstanceName<TAGENT>(agentInstanceName, null, null);
		}

		// Token: 0x0601A3B9 RID: 107449 RVA: 0x006D7D2B File Offset: 0x006D612B
		public static bool RegisterInstanceName<TAGENT>() where TAGENT : Agent
		{
			return Agent.RegisterInstanceName<TAGENT>(null, null, null);
		}

		// Token: 0x0601A3BA RID: 107450 RVA: 0x006D7D38 File Offset: 0x006D6138
		public static bool RegisterStaticClass(Type type, string displayName, string desc)
		{
			string fullName = type.FullName;
			if (!Agent.Names.ContainsKey(fullName))
			{
				Agent.Names[fullName] = new Agent.AgentName_t(fullName, fullName, displayName, desc);
				Utils.AddStaticClass(type);
				return true;
			}
			return false;
		}

		// Token: 0x0601A3BB RID: 107451 RVA: 0x006D7D7C File Offset: 0x006D617C
		public static void UnRegisterInstanceName<TAGENT>(string agentInstanceName) where TAGENT : Agent
		{
			string text = agentInstanceName;
			if (string.IsNullOrEmpty(text))
			{
				text = typeof(TAGENT).FullName;
			}
			if (Agent.Names.ContainsKey(text))
			{
				Agent.Names.Remove(text);
			}
		}

		// Token: 0x0601A3BC RID: 107452 RVA: 0x006D7DC2 File Offset: 0x006D61C2
		public static void UnRegisterInstanceName<TAGENT>() where TAGENT : Agent
		{
			Agent.UnRegisterInstanceName<TAGENT>(null);
		}

		// Token: 0x0601A3BD RID: 107453 RVA: 0x006D7DCA File Offset: 0x006D61CA
		public static bool IsNameRegistered(string agentInstanceName)
		{
			return Agent.Names.ContainsKey(agentInstanceName);
		}

		// Token: 0x0601A3BE RID: 107454 RVA: 0x006D7DD8 File Offset: 0x006D61D8
		public static string GetRegisteredClassName(string agentInstanceName)
		{
			if (Agent.Names.ContainsKey(agentInstanceName))
			{
				return Agent.Names[agentInstanceName].ClassName;
			}
			return null;
		}

		// Token: 0x0601A3BF RID: 107455 RVA: 0x006D7E0C File Offset: 0x006D620C
		public static bool BindInstance(Agent pAgentInstance, string agentInstanceName, int contextId)
		{
			Context context = Context.GetContext(contextId);
			return context != null && context.BindInstance(pAgentInstance, agentInstanceName);
		}

		// Token: 0x0601A3C0 RID: 107456 RVA: 0x006D7E30 File Offset: 0x006D6230
		public static bool BindInstance(Agent pAgentInstance, string agentInstanceName)
		{
			return Agent.BindInstance(pAgentInstance, agentInstanceName, 0);
		}

		// Token: 0x0601A3C1 RID: 107457 RVA: 0x006D7E3A File Offset: 0x006D623A
		public static bool BindInstance(Agent pAgentInstance)
		{
			return Agent.BindInstance(pAgentInstance, null, 0);
		}

		// Token: 0x0601A3C2 RID: 107458 RVA: 0x006D7E44 File Offset: 0x006D6244
		public static bool UnbindInstance(string agentInstanceName, int contextId)
		{
			Context context = Context.GetContext(contextId);
			return context != null && context.UnbindInstance(agentInstanceName);
		}

		// Token: 0x0601A3C3 RID: 107459 RVA: 0x006D7E67 File Offset: 0x006D6267
		public static bool UnbindInstance(string agentInstanceName)
		{
			return Agent.UnbindInstance(agentInstanceName, 0);
		}

		// Token: 0x0601A3C4 RID: 107460 RVA: 0x006D7E70 File Offset: 0x006D6270
		public static bool UnbindInstance<T>()
		{
			string fullName = typeof(T).FullName;
			return Agent.UnbindInstance(fullName);
		}

		// Token: 0x0601A3C5 RID: 107461 RVA: 0x006D7E94 File Offset: 0x006D6294
		public static Agent GetInstance(string agentInstanceName, int contextId)
		{
			Context context = Context.GetContext(contextId);
			if (context != null)
			{
				return context.GetInstance(agentInstanceName);
			}
			return null;
		}

		// Token: 0x0601A3C6 RID: 107462 RVA: 0x006D7EB7 File Offset: 0x006D62B7
		public static Agent GetInstance(string agentInstanceName)
		{
			return Agent.GetInstance(agentInstanceName, 0);
		}

		// Token: 0x0601A3C7 RID: 107463 RVA: 0x006D7EC0 File Offset: 0x006D62C0
		public static TAGENT GetInstance<TAGENT>(string agentInstanceName, int contextId) where TAGENT : Agent, new()
		{
			string text = agentInstanceName;
			if (string.IsNullOrEmpty(text))
			{
				text = typeof(TAGENT).FullName;
			}
			Agent instance = Agent.GetInstance(text, contextId);
			return (TAGENT)((object)instance);
		}

		// Token: 0x0601A3C8 RID: 107464 RVA: 0x006D7EFA File Offset: 0x006D62FA
		public static TAGENT GetInstance<TAGENT>(string agentInstanceName) where TAGENT : Agent, new()
		{
			return Agent.GetInstance<TAGENT>(agentInstanceName, 0);
		}

		// Token: 0x0601A3C9 RID: 107465 RVA: 0x006D7F03 File Offset: 0x006D6303
		public static TAGENT GetInstance<TAGENT>() where TAGENT : Agent, new()
		{
			return Agent.GetInstance<TAGENT>(null, 0);
		}

		// Token: 0x0601A3CA RID: 107466 RVA: 0x006D7F0C File Offset: 0x006D630C
		private Dictionary<uint, IInstantiatedVariable> GetCustomizedVariables()
		{
			string classTypeName = this.GetClassTypeName();
			uint classId = Utils.MakeVariableId(classTypeName);
			AgentMeta meta = AgentMeta.GetMeta(classId);
			if (meta != null)
			{
				return meta.InstantiateCustomizedProperties();
			}
			return null;
		}

		// Token: 0x1700225E RID: 8798
		// (get) Token: 0x0601A3CB RID: 107467 RVA: 0x006D7F40 File Offset: 0x006D6340
		public Variables Variables
		{
			get
			{
				if (this.m_variables == null)
				{
					Dictionary<uint, IInstantiatedVariable> customizedVariables = this.GetCustomizedVariables();
					this.m_variables = new Variables(customizedVariables);
				}
				return this.m_variables;
			}
		}

		// Token: 0x0601A3CC RID: 107468 RVA: 0x006D7F74 File Offset: 0x006D6374
		internal IInstantiatedVariable GetInstantiatedVariable(uint varId)
		{
			if (this.ExcutingTreeTask != null && this.ExcutingTreeTask.LocalVars.ContainsKey(varId))
			{
				return this.ExcutingTreeTask.LocalVars[varId];
			}
			return this.Variables.GetVariable(varId);
		}

		// Token: 0x0601A3CD RID: 107469 RVA: 0x006D7FC4 File Offset: 0x006D63C4
		private IProperty GetProperty(uint propId)
		{
			string classTypeName = this.GetClassTypeName();
			uint classId = Utils.MakeVariableId(classTypeName);
			AgentMeta meta = AgentMeta.GetMeta(classId);
			if (meta != null)
			{
				IProperty property = meta.GetProperty(propId);
				if (property != null)
				{
					return property;
				}
			}
			return null;
		}

		// Token: 0x0601A3CE RID: 107470 RVA: 0x006D8000 File Offset: 0x006D6400
		internal bool GetVarValue<VariableType>(uint varId, out VariableType value)
		{
			IInstantiatedVariable instantiatedVariable = this.GetInstantiatedVariable(varId);
			if (instantiatedVariable != null)
			{
				if (!typeof(VariableType).IsValueType)
				{
					value = (VariableType)((object)instantiatedVariable.GetValueObject(this));
					return true;
				}
				CVariable<VariableType> cvariable = (CVariable<VariableType>)instantiatedVariable;
				if (cvariable != null)
				{
					value = cvariable.GetValue(this);
					return true;
				}
			}
			value = default(VariableType);
			return false;
		}

		// Token: 0x0601A3CF RID: 107471 RVA: 0x006D8074 File Offset: 0x006D6474
		private bool GetVarValue<VariableType>(uint varId, int index, out VariableType value)
		{
			IInstantiatedVariable instantiatedVariable = this.GetInstantiatedVariable(varId);
			if (instantiatedVariable != null)
			{
				CArrayItemVariable<VariableType> carrayItemVariable = (CArrayItemVariable<VariableType>)instantiatedVariable;
				if (carrayItemVariable != null)
				{
					value = carrayItemVariable.GetValue(this, index);
					return true;
				}
			}
			value = default(VariableType);
			return false;
		}

		// Token: 0x0601A3D0 RID: 107472 RVA: 0x006D80BC File Offset: 0x006D64BC
		internal bool SetVarValue<VariableType>(uint varId, VariableType value)
		{
			IInstantiatedVariable instantiatedVariable = this.GetInstantiatedVariable(varId);
			if (instantiatedVariable != null)
			{
				CVariable<VariableType> cvariable = (CVariable<VariableType>)instantiatedVariable;
				if (cvariable != null)
				{
					cvariable.SetValue(this, value);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0601A3D1 RID: 107473 RVA: 0x006D80F0 File Offset: 0x006D64F0
		private bool SetVarValue<VariableType>(uint varId, int index, VariableType value)
		{
			IInstantiatedVariable instantiatedVariable = this.GetInstantiatedVariable(varId);
			if (instantiatedVariable != null)
			{
				CArrayItemVariable<VariableType> carrayItemVariable = (CArrayItemVariable<VariableType>)instantiatedVariable;
				if (carrayItemVariable != null)
				{
					carrayItemVariable.SetValue(this, value, index);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0601A3D2 RID: 107474 RVA: 0x006D8124 File Offset: 0x006D6524
		public bool IsValidVariable(string variableName)
		{
			uint num = Utils.MakeVariableId(variableName);
			IInstantiatedVariable instantiatedVariable = this.GetInstantiatedVariable(num);
			if (instantiatedVariable != null)
			{
				return true;
			}
			IProperty property = this.GetProperty(num);
			return property != null;
		}

		// Token: 0x0601A3D3 RID: 107475 RVA: 0x006D8158 File Offset: 0x006D6558
		public VariableType GetVariable<VariableType>(string variableName)
		{
			uint variableId = Utils.MakeVariableId(variableName);
			return this.GetVariable<VariableType>(variableId);
		}

		// Token: 0x0601A3D4 RID: 107476 RVA: 0x006D8174 File Offset: 0x006D6574
		internal VariableType GetVariable<VariableType>(uint variableId)
		{
			VariableType result;
			if (this.GetVarValue<VariableType>(variableId, out result))
			{
				return result;
			}
			IProperty property = this.GetProperty(variableId);
			if (property != null)
			{
				if (!typeof(VariableType).IsValueType)
				{
					return (VariableType)((object)property.GetValueObject(this));
				}
				CProperty<VariableType> cproperty = (CProperty<VariableType>)property;
				if (cproperty != null)
				{
					return cproperty.GetValue(this);
				}
			}
			return default(VariableType);
		}

		// Token: 0x0601A3D5 RID: 107477 RVA: 0x006D81E4 File Offset: 0x006D65E4
		internal VariableType GetVariable<VariableType>(uint variableId, int index)
		{
			VariableType result;
			if (this.GetVarValue<VariableType>(variableId, index, out result))
			{
				return result;
			}
			IProperty property = this.GetProperty(variableId);
			if (property != null)
			{
				if (!typeof(VariableType).IsValueType)
				{
					return (VariableType)((object)property.GetValueObject(this, index));
				}
				CProperty<VariableType> cproperty = (CProperty<VariableType>)property;
				if (cproperty != null)
				{
					return cproperty.GetValue(this, index);
				}
			}
			return default(VariableType);
		}

		// Token: 0x0601A3D6 RID: 107478 RVA: 0x006D8258 File Offset: 0x006D6658
		public void SetVariable<VariableType>(string variableName, VariableType value)
		{
			uint variableId = Utils.MakeVariableId(variableName);
			this.SetVariable<VariableType>(variableName, variableId, value);
		}

		// Token: 0x0601A3D7 RID: 107479 RVA: 0x006D8278 File Offset: 0x006D6678
		public void SetVariable<VariableType>(string variableName, uint variableId, VariableType value)
		{
			if (variableId == 0U)
			{
				variableId = Utils.MakeVariableId(variableName);
			}
			if (this.SetVarValue<VariableType>(variableId, value))
			{
				return;
			}
			IProperty property = this.GetProperty(variableId);
			if (property != null)
			{
				CProperty<VariableType> cproperty = (CProperty<VariableType>)property;
				if (cproperty != null)
				{
					cproperty.SetValue(this, value);
					return;
				}
			}
		}

		// Token: 0x0601A3D8 RID: 107480 RVA: 0x006D82C8 File Offset: 0x006D66C8
		public void SetVariable<VariableType>(string variableName, uint variableId, VariableType value, int index)
		{
			if (variableId == 0U)
			{
				variableId = Utils.MakeVariableId(variableName);
			}
			if (this.SetVarValue<VariableType>(variableId, index, value))
			{
				return;
			}
			IProperty property = this.GetProperty(variableId);
			if (property != null)
			{
				CProperty<VariableType> cproperty = (CProperty<VariableType>)property;
				if (cproperty != null)
				{
					cproperty.SetValue(this, value, index);
					return;
				}
			}
		}

		// Token: 0x0601A3D9 RID: 107481 RVA: 0x006D831C File Offset: 0x006D671C
		internal void SetVariableFromString(string variableName, string valueStr)
		{
			uint num = Utils.MakeVariableId(variableName);
			IInstantiatedVariable instantiatedVariable = this.GetInstantiatedVariable(num);
			if (instantiatedVariable != null)
			{
				instantiatedVariable.SetValueFromString(this, valueStr);
				return;
			}
			IProperty property = this.GetProperty(num);
			if (property != null)
			{
				property.SetValueFromString(this, valueStr);
			}
		}

		// Token: 0x0601A3DA RID: 107482 RVA: 0x006D835D File Offset: 0x006D675D
		public void LogVariables(bool bForce)
		{
		}

		// Token: 0x0601A3DB RID: 107483 RVA: 0x006D835F File Offset: 0x006D675F
		public void LogRunningNodes()
		{
		}

		// Token: 0x0601A3DC RID: 107484 RVA: 0x006D8361 File Offset: 0x006D6761
		protected static void Init_(int contextId, Agent pAgent, int priority)
		{
			pAgent.m_contextId = contextId;
			pAgent.m_id = Agent.ms_agent_index++;
			pAgent.m_priority = priority;
			pAgent.SetName(pAgent.name);
			Context.AddAgent(pAgent);
		}

		// Token: 0x0601A3DD RID: 107485 RVA: 0x006D8396 File Offset: 0x006D6796
		public void btresetcurrrent()
		{
			if (this.m_currentBT != null)
			{
				this.m_currentBT.reset(this);
			}
		}

		// Token: 0x0601A3DE RID: 107486 RVA: 0x006D83AF File Offset: 0x006D67AF
		public void btsetcurrent(string relativePath)
		{
			this._btsetcurrent(relativePath, TriggerMode.TM_Transfer, false);
		}

		// Token: 0x0601A3DF RID: 107487 RVA: 0x006D83BA File Offset: 0x006D67BA
		public void btreferencetree(string relativePath)
		{
			this._btsetcurrent(relativePath, TriggerMode.TM_Return, false);
			this.m_referencetree = true;
		}

		// Token: 0x0601A3E0 RID: 107488 RVA: 0x006D83CC File Offset: 0x006D67CC
		public void bteventtree(Agent pAgent, string relativePath, TriggerMode triggerMode)
		{
			this._btsetcurrent(relativePath, triggerMode, true);
		}

		// Token: 0x0601A3E1 RID: 107489 RVA: 0x006D83D8 File Offset: 0x006D67D8
		private void _btsetcurrent(string relativePath, TriggerMode triggerMode, bool bByEvent)
		{
			if (!string.IsNullOrEmpty(relativePath))
			{
				if (!Workspace.Instance.Load(relativePath))
				{
					string str = base.GetType().FullName;
					str += "::";
					str += this.name;
				}
				else
				{
					Workspace.Instance.RecordBTAgentMapping(relativePath, this);
					if (this.m_currentBT != null)
					{
						if (triggerMode == TriggerMode.TM_Return)
						{
							Agent.BehaviorTreeStackItem_t item = new Agent.BehaviorTreeStackItem_t(this.m_currentBT, triggerMode, bByEvent);
							this.BTStack.Add(item);
						}
						else if (triggerMode == TriggerMode.TM_Transfer && this.m_currentBT.GetName() != relativePath)
						{
							this.m_currentBT.abort(this);
						}
					}
					BehaviorTreeTask behaviorTreeTask = null;
					for (int i = 0; i < this.BehaviorTreeTasks.Count; i++)
					{
						BehaviorTreeTask behaviorTreeTask2 = this.BehaviorTreeTasks[i];
						if (behaviorTreeTask2.GetName() == relativePath)
						{
							behaviorTreeTask = behaviorTreeTask2;
							break;
						}
					}
					bool flag = false;
					if (behaviorTreeTask != null && this.BTStack.Count > 0)
					{
						for (int j = 0; j < this.BTStack.Count; j++)
						{
							Agent.BehaviorTreeStackItem_t behaviorTreeStackItem_t = this.BTStack[j];
							if (behaviorTreeStackItem_t.bt.GetName() == relativePath)
							{
								flag = true;
								break;
							}
						}
						if (behaviorTreeTask.GetStatus() != EBTStatus.BT_INVALID)
						{
							behaviorTreeTask.reset(this);
						}
					}
					if (behaviorTreeTask == null || flag)
					{
						behaviorTreeTask = Workspace.Instance.CreateBehaviorTreeTask(relativePath);
						this.BehaviorTreeTasks.Add(behaviorTreeTask);
					}
					this.CurrentTreeTask = behaviorTreeTask;
				}
			}
		}

		// Token: 0x0601A3E2 RID: 107490 RVA: 0x006D8594 File Offset: 0x006D6994
		private EBTStatus btexec_()
		{
			if (this.m_currentBT != null)
			{
				BehaviorTreeTask currentBT = this.m_currentBT;
				EBTStatus ebtstatus = this.m_currentBT.exec(this);
				while (ebtstatus != EBTStatus.BT_RUNNING)
				{
					if (this.BTStack.Count <= 0)
					{
						break;
					}
					Agent.BehaviorTreeStackItem_t behaviorTreeStackItem_t = this.BTStack[this.BTStack.Count - 1];
					this.CurrentTreeTask = behaviorTreeStackItem_t.bt;
					this.BTStack.RemoveAt(this.BTStack.Count - 1);
					bool flag = false;
					if (behaviorTreeStackItem_t.triggerMode == TriggerMode.TM_Return)
					{
						if (!behaviorTreeStackItem_t.triggerByEvent)
						{
							if (this.m_currentBT != currentBT)
							{
								ebtstatus = this.m_currentBT.resume(this, ebtstatus);
							}
						}
						else
						{
							flag = true;
						}
					}
					else
					{
						flag = true;
					}
					if (flag)
					{
						currentBT = this.m_currentBT;
						ebtstatus = this.m_currentBT.exec(this);
						break;
					}
				}
				if (ebtstatus != EBTStatus.BT_RUNNING)
				{
					this.ExcutingTreeTask = null;
				}
				return ebtstatus;
			}
			return EBTStatus.BT_INVALID;
		}

		// Token: 0x0601A3E3 RID: 107491 RVA: 0x006D869A File Offset: 0x006D6A9A
		public void LogJumpTree(string newTree)
		{
		}

		// Token: 0x0601A3E4 RID: 107492 RVA: 0x006D869C File Offset: 0x006D6A9C
		public void LogReturnTree(string returnFromTree)
		{
		}

		// Token: 0x0601A3E5 RID: 107493 RVA: 0x006D86A0 File Offset: 0x006D6AA0
		public virtual EBTStatus btexec()
		{
			if (this.m_bActive)
			{
				EBTStatus ebtstatus = this.btexec_();
				while (this.m_referencetree && ebtstatus == EBTStatus.BT_RUNNING)
				{
					this.m_referencetree = false;
					ebtstatus = this.btexec_();
				}
				if (this.IsMasked())
				{
					this.LogVariables(false);
				}
				return ebtstatus;
			}
			return EBTStatus.BT_INVALID;
		}

		// Token: 0x0601A3E6 RID: 107494 RVA: 0x006D86FC File Offset: 0x006D6AFC
		public bool btload(string relativePath, bool bForce)
		{
			bool flag = Workspace.Instance.Load(relativePath, bForce);
			if (flag)
			{
				Workspace.Instance.RecordBTAgentMapping(relativePath, this);
			}
			return flag;
		}

		// Token: 0x0601A3E7 RID: 107495 RVA: 0x006D872C File Offset: 0x006D6B2C
		public bool btload(string relativePath)
		{
			return this.btload(relativePath, false);
		}

		// Token: 0x0601A3E8 RID: 107496 RVA: 0x006D8744 File Offset: 0x006D6B44
		public void btunload(string relativePath)
		{
			if (this.m_currentBT != null && this.m_currentBT.GetName() == relativePath)
			{
				BehaviorNode node = this.m_currentBT.GetNode();
				BehaviorTree bt = node as BehaviorTree;
				this.btunload_pars(bt);
				this.CurrentTreeTask = null;
			}
			for (int i = 0; i < this.BTStack.Count; i++)
			{
				Agent.BehaviorTreeStackItem_t behaviorTreeStackItem_t = this.BTStack[i];
				if (behaviorTreeStackItem_t.bt.GetName() == relativePath)
				{
					this.BTStack.Remove(behaviorTreeStackItem_t);
					break;
				}
			}
			for (int j = 0; j < this.BehaviorTreeTasks.Count; j++)
			{
				BehaviorTreeTask behaviorTreeTask = this.BehaviorTreeTasks[j];
				if (behaviorTreeTask.GetName() == relativePath)
				{
					Workspace.Instance.DestroyBehaviorTreeTask(behaviorTreeTask, this);
					this.BehaviorTreeTasks.Remove(behaviorTreeTask);
					break;
				}
			}
			Workspace.Instance.UnLoad(relativePath);
		}

		// Token: 0x0601A3E9 RID: 107497 RVA: 0x006D8850 File Offset: 0x006D6C50
		public virtual void bthotreloaded(BehaviorTree bt)
		{
			this.btunload_pars(bt);
		}

		// Token: 0x0601A3EA RID: 107498 RVA: 0x006D885C File Offset: 0x006D6C5C
		public void btunloadall()
		{
			List<BehaviorTree> list = new List<BehaviorTree>();
			for (int i = 0; i < this.BehaviorTreeTasks.Count; i++)
			{
				BehaviorTreeTask behaviorTreeTask = this.BehaviorTreeTasks[i];
				BehaviorNode node = behaviorTreeTask.GetNode();
				BehaviorTree behaviorTree = (BehaviorTree)node;
				bool flag = false;
				for (int j = 0; j < list.Count; j++)
				{
					BehaviorTree behaviorTree2 = list[j];
					if (behaviorTree2 == behaviorTree)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(behaviorTree);
				}
				Workspace.Instance.DestroyBehaviorTreeTask(behaviorTreeTask, this);
			}
			for (int k = 0; k < list.Count; k++)
			{
				BehaviorTree behaviorTree3 = list[k];
				this.btunload_pars(behaviorTree3);
				Workspace.Instance.UnLoad(behaviorTree3.GetName());
			}
			this.BehaviorTreeTasks.Clear();
			this.CurrentTreeTask = null;
			this.BTStack.Clear();
			this.Variables.Unload();
		}

		// Token: 0x0601A3EB RID: 107499 RVA: 0x006D8964 File Offset: 0x006D6D64
		public void btreloadall()
		{
			this.CurrentTreeTask = null;
			this.BTStack.Clear();
			if (this.m_behaviorTreeTasks != null)
			{
				List<string> list = new List<string>();
				for (int i = 0; i < this.m_behaviorTreeTasks.Count; i++)
				{
					BehaviorTreeTask behaviorTreeTask = this.m_behaviorTreeTasks[i];
					string item = behaviorTreeTask.GetName();
					if (list.IndexOf(item) == -1)
					{
						list.Add(item);
					}
				}
				for (int j = 0; j < list.Count; j++)
				{
					string relativePath = list[j];
					Workspace.Instance.Load(relativePath, true);
				}
				this.BehaviorTreeTasks.Clear();
			}
			this.Variables.Unload();
		}

		// Token: 0x0601A3EC RID: 107500 RVA: 0x006D8A24 File Offset: 0x006D6E24
		public bool btsave(Agent.State_t state)
		{
			this.Variables.CopyTo(null, state.Vars);
			if (this.m_currentBT != null)
			{
				Workspace.Instance.DestroyBehaviorTreeTask(state.BT, this);
				BehaviorNode node = this.m_currentBT.GetNode();
				if (node != null)
				{
					state.BT = (BehaviorTreeTask)node.CreateAndInitTask();
					this.m_currentBT.CopyTo(state.BT);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0601A3ED RID: 107501 RVA: 0x006D8A98 File Offset: 0x006D6E98
		public bool btload(Agent.State_t state)
		{
			state.Vars.CopyTo(this, this.m_variables);
			if (state.BT != null)
			{
				if (this.m_currentBT != null)
				{
					for (int i = 0; i < this.m_behaviorTreeTasks.Count; i++)
					{
						BehaviorTreeTask behaviorTreeTask = this.m_behaviorTreeTasks[i];
						if (behaviorTreeTask == this.m_currentBT)
						{
							Workspace.Instance.DestroyBehaviorTreeTask(behaviorTreeTask, this);
							this.m_behaviorTreeTasks.Remove(behaviorTreeTask);
							break;
						}
					}
				}
				BehaviorNode node = state.BT.GetNode();
				if (node != null)
				{
					this.m_currentBT = (BehaviorTreeTask)node.CreateAndInitTask();
					state.BT.CopyTo(this.m_currentBT);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0601A3EE RID: 107502 RVA: 0x006D8B57 File Offset: 0x006D6F57
		private void btunload_pars(BehaviorTree bt)
		{
			if (bt.LocalProps != null)
			{
				bt.LocalProps.Clear();
			}
		}

		// Token: 0x0601A3EF RID: 107503 RVA: 0x006D8B70 File Offset: 0x006D6F70
		public void btonevent(string btEvent, Dictionary<uint, IInstantiatedVariable> eventParams)
		{
			if (this.m_currentBT != null)
			{
				string classTypeName = this.GetClassTypeName();
				uint classId = Utils.MakeVariableId(classTypeName);
				AgentMeta meta = AgentMeta.GetMeta(classId);
				if (meta != null)
				{
					uint methodId = Utils.MakeVariableId(btEvent);
					IMethod method = meta.GetMethod(methodId);
					if (method != null)
					{
						this.m_currentBT.onevent(this, btEvent, eventParams);
					}
				}
			}
		}

		// Token: 0x0601A3F0 RID: 107504 RVA: 0x006D8BCE File Offset: 0x006D6FCE
		public void FireEvent(string eventName)
		{
			this.btonevent(eventName, null);
		}

		// Token: 0x0601A3F1 RID: 107505 RVA: 0x006D8BD8 File Offset: 0x006D6FD8
		public void FireEvent<ParamType>(string eventName, ParamType param)
		{
			Dictionary<uint, IInstantiatedVariable> dictionary = new Dictionary<uint, IInstantiatedVariable>();
			string idstring = string.Format("{0}{1}", "_$local_task_param_$_", 0);
			uint key = Utils.MakeVariableId(idstring);
			dictionary[key] = new CVariable<ParamType>(idstring, param);
			this.btonevent(eventName, dictionary);
		}

		// Token: 0x0601A3F2 RID: 107506 RVA: 0x006D8C20 File Offset: 0x006D7020
		public void FireEvent<ParamType1, ParamType2>(string eventName, ParamType1 param1, ParamType2 param2)
		{
			Dictionary<uint, IInstantiatedVariable> dictionary = new Dictionary<uint, IInstantiatedVariable>();
			string idstring = string.Format("{0}{1}", "_$local_task_param_$_", 0);
			uint key = Utils.MakeVariableId(idstring);
			dictionary[key] = new CVariable<ParamType1>(idstring, param1);
			idstring = string.Format("{0}{1}", "_$local_task_param_$_", 1);
			key = Utils.MakeVariableId(idstring);
			dictionary[key] = new CVariable<ParamType2>(idstring, param2);
			this.btonevent(eventName, dictionary);
		}

		// Token: 0x0601A3F3 RID: 107507 RVA: 0x006D8C94 File Offset: 0x006D7094
		public void FireEvent<ParamType1, ParamType2, ParamType3>(string eventName, ParamType1 param1, ParamType2 param2, ParamType3 param3)
		{
			Dictionary<uint, IInstantiatedVariable> dictionary = new Dictionary<uint, IInstantiatedVariable>();
			string idstring = string.Format("{0}{1}", "_$local_task_param_$_", 0);
			uint key = Utils.MakeVariableId(idstring);
			dictionary[key] = new CVariable<ParamType1>(idstring, param1);
			idstring = string.Format("{0}{1}", "_$local_task_param_$_", 1);
			key = Utils.MakeVariableId(idstring);
			dictionary[key] = new CVariable<ParamType2>(idstring, param2);
			idstring = string.Format("{0}{1}", "_$local_task_param_$_", 2);
			key = Utils.MakeVariableId(idstring);
			dictionary[key] = new CVariable<ParamType3>(idstring, param3);
			this.btonevent(eventName, dictionary);
		}

		// Token: 0x0601A3F4 RID: 107508 RVA: 0x006D8D34 File Offset: 0x006D7134
		[MethodMetaInfo]
		public static void LogMessage(string message)
		{
			int frameSinceStartup = Workspace.Instance.FrameSinceStartup;
		}

		// Token: 0x0601A3F5 RID: 107509 RVA: 0x006D8D4C File Offset: 0x006D714C
		[MethodMetaInfo]
		public static int VectorLength(IList vector)
		{
			if (vector != null)
			{
				return vector.Count;
			}
			return 0;
		}

		// Token: 0x0601A3F6 RID: 107510 RVA: 0x006D8D5C File Offset: 0x006D715C
		[MethodMetaInfo]
		public static void VectorAdd(IList vector, object element)
		{
			if (vector != null)
			{
				vector.Add(element);
			}
		}

		// Token: 0x0601A3F7 RID: 107511 RVA: 0x006D8D6C File Offset: 0x006D716C
		[MethodMetaInfo]
		public static void VectorRemove(IList vector, object element)
		{
			if (vector != null)
			{
				vector.Remove(element);
			}
		}

		// Token: 0x0601A3F8 RID: 107512 RVA: 0x006D8D7C File Offset: 0x006D717C
		[MethodMetaInfo]
		public static bool VectorContains(IList vector, object element)
		{
			return vector != null && vector.IndexOf(element) > -1;
		}

		// Token: 0x0601A3F9 RID: 107513 RVA: 0x006D8D9D File Offset: 0x006D719D
		[MethodMetaInfo]
		public static void VectorClear(IList vector)
		{
			if (vector != null)
			{
				vector.Clear();
			}
		}

		// Token: 0x040126D0 RID: 75472
		private string name;

		// Token: 0x040126D1 RID: 75473
		private List<BehaviorTreeTask> m_behaviorTreeTasks;

		// Token: 0x040126D2 RID: 75474
		private List<Agent.BehaviorTreeStackItem_t> m_btStack;

		// Token: 0x040126D3 RID: 75475
		private BehaviorTreeTask m_currentBT;

		// Token: 0x040126D4 RID: 75476
		private BehaviorTreeTask m_excutingTreeTask;

		// Token: 0x040126D5 RID: 75477
		private int m_id = -1;

		// Token: 0x040126D6 RID: 75478
		private bool m_bActive = true;

		// Token: 0x040126D7 RID: 75479
		private bool m_referencetree;

		// Token: 0x040126D8 RID: 75480
		public int m_priority;

		// Token: 0x040126D9 RID: 75481
		public int m_contextId;

		// Token: 0x040126DA RID: 75482
		private static uint ms_idMask = uint.MaxValue;

		// Token: 0x040126DB RID: 75483
		private uint m_idFlag = uint.MaxValue;

		// Token: 0x040126DC RID: 75484
		private static int ms_agent_index;

		// Token: 0x040126DD RID: 75485
		private static Dictionary<string, int> ms_agent_type_index;

		// Token: 0x040126DE RID: 75486
		private static Dictionary<string, Agent.AgentName_t> ms_names;

		// Token: 0x040126DF RID: 75487
		private Variables m_variables;

		// Token: 0x02004753 RID: 18259
		public class State_t
		{
			// Token: 0x0601A3FB RID: 107515 RVA: 0x006D8DB4 File Offset: 0x006D71B4
			public State_t(Agent.State_t c)
			{
				c.m_vars.CopyTo(null, this.m_vars);
				if (c.m_bt != null)
				{
					BehaviorNode node = c.m_bt.GetNode();
					if (node != null)
					{
						this.m_bt = (BehaviorTreeTask)node.CreateAndInitTask();
						c.m_bt.CopyTo(this.m_bt);
					}
				}
			}

			// Token: 0x1700225F RID: 8799
			// (get) Token: 0x0601A3FC RID: 107516 RVA: 0x006D8E23 File Offset: 0x006D7223
			public Variables Vars
			{
				get
				{
					return this.m_vars;
				}
			}

			// Token: 0x17002260 RID: 8800
			// (get) Token: 0x0601A3FD RID: 107517 RVA: 0x006D8E2B File Offset: 0x006D722B
			// (set) Token: 0x0601A3FE RID: 107518 RVA: 0x006D8E33 File Offset: 0x006D7233
			public BehaviorTreeTask BT
			{
				get
				{
					return this.m_bt;
				}
				set
				{
					this.m_bt = value;
				}
			}

			// Token: 0x0601A3FF RID: 107519 RVA: 0x006D8E3C File Offset: 0x006D723C
			public bool SaveToFile(string fileName)
			{
				return false;
			}

			// Token: 0x0601A400 RID: 107520 RVA: 0x006D8E3F File Offset: 0x006D723F
			public bool LoadFromFile(string fileName)
			{
				return false;
			}

			// Token: 0x040126E0 RID: 75488
			protected Variables m_vars = new Variables();

			// Token: 0x040126E1 RID: 75489
			protected BehaviorTreeTask m_bt;
		}

		// Token: 0x02004754 RID: 18260
		private class BehaviorTreeStackItem_t
		{
			// Token: 0x0601A401 RID: 107521 RVA: 0x006D8E42 File Offset: 0x006D7242
			public BehaviorTreeStackItem_t(BehaviorTreeTask bt_, TriggerMode tm, bool bByEvent)
			{
				this.bt = bt_;
				this.triggerMode = tm;
				this.triggerByEvent = bByEvent;
			}

			// Token: 0x040126E2 RID: 75490
			public BehaviorTreeTask bt;

			// Token: 0x040126E3 RID: 75491
			public TriggerMode triggerMode;

			// Token: 0x040126E4 RID: 75492
			public bool triggerByEvent;
		}

		// Token: 0x02004755 RID: 18261
		internal struct AgentName_t
		{
			// Token: 0x0601A402 RID: 107522 RVA: 0x006D8E60 File Offset: 0x006D7260
			public AgentName_t(string instanceName, string className, string displayName, string desc)
			{
				this.instantceName_ = instanceName;
				this.className_ = className;
				if (!string.IsNullOrEmpty(displayName))
				{
					this.displayName_ = displayName;
				}
				else
				{
					this.displayName_ = this.instantceName_.Replace(".", "::");
				}
				if (!string.IsNullOrEmpty(desc))
				{
					this.desc_ = desc;
				}
				else
				{
					this.desc_ = this.displayName_;
				}
			}

			// Token: 0x17002261 RID: 8801
			// (get) Token: 0x0601A403 RID: 107523 RVA: 0x006D8ED2 File Offset: 0x006D72D2
			public string ClassName
			{
				get
				{
					return this.className_;
				}
			}

			// Token: 0x040126E5 RID: 75493
			public string instantceName_;

			// Token: 0x040126E6 RID: 75494
			public string className_;

			// Token: 0x040126E7 RID: 75495
			public string displayName_;

			// Token: 0x040126E8 RID: 75496
			public string desc_;
		}

		// Token: 0x02004756 RID: 18262
		[TypeConverter]
		public class StructConverter : TypeConverter
		{
			// Token: 0x0601A405 RID: 107525 RVA: 0x006D8EE2 File Offset: 0x006D72E2
			public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
			{
				return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
			}

			// Token: 0x0601A406 RID: 107526 RVA: 0x006D8EFE File Offset: 0x006D72FE
			public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
			{
				if (value is string)
				{
				}
				return base.ConvertFrom(context, culture, value);
			}

			// Token: 0x0601A407 RID: 107527 RVA: 0x006D8F14 File Offset: 0x006D7314
			public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
			{
				if (destinationType == typeof(string))
				{
				}
				return base.ConvertTo(context, culture, value, destinationType);
			}
		}
	}
}
