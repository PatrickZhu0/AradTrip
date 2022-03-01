using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020048B7 RID: 18615
	public class Variables
	{
		// Token: 0x0601AC38 RID: 109624 RVA: 0x0083C41C File Offset: 0x0083A81C
		public Variables(Dictionary<uint, IInstantiatedVariable> vars)
		{
			this.m_variables = vars;
		}

		// Token: 0x0601AC39 RID: 109625 RVA: 0x0083C436 File Offset: 0x0083A836
		public Variables()
		{
			this.m_variables = new Dictionary<uint, IInstantiatedVariable>();
		}

		// Token: 0x0601AC3A RID: 109626 RVA: 0x0083C454 File Offset: 0x0083A854
		public bool IsExisting(uint varId)
		{
			return this.m_variables.ContainsKey(varId);
		}

		// Token: 0x0601AC3B RID: 109627 RVA: 0x0083C462 File Offset: 0x0083A862
		public virtual IInstantiatedVariable GetVariable(uint varId)
		{
			if (this.m_variables != null && this.m_variables.ContainsKey(varId))
			{
				return this.m_variables[varId];
			}
			return null;
		}

		// Token: 0x0601AC3C RID: 109628 RVA: 0x0083C48E File Offset: 0x0083A88E
		public virtual void AddVariable(uint varId, IInstantiatedVariable pVar, int stackIndex)
		{
			this.m_variables[varId] = pVar;
		}

		// Token: 0x0601AC3D RID: 109629 RVA: 0x0083C49D File Offset: 0x0083A89D
		public void Log(Agent agent)
		{
		}

		// Token: 0x0601AC3E RID: 109630 RVA: 0x0083C4A0 File Offset: 0x0083A8A0
		public void UnLoad(string variableName)
		{
			uint key = Utils.MakeVariableId(variableName);
			if (this.m_variables.ContainsKey(key))
			{
				this.m_variables.Remove(key);
			}
		}

		// Token: 0x0601AC3F RID: 109631 RVA: 0x0083C4D2 File Offset: 0x0083A8D2
		public void Unload()
		{
		}

		// Token: 0x0601AC40 RID: 109632 RVA: 0x0083C4D4 File Offset: 0x0083A8D4
		public void CopyTo(Agent pAgent, Variables target)
		{
			target.m_variables.Clear();
			foreach (uint key in this.m_variables.Keys)
			{
				IInstantiatedVariable instantiatedVariable = this.m_variables[key];
				IInstantiatedVariable value = instantiatedVariable.clone();
				target.m_variables[key] = value;
			}
			if (!object.ReferenceEquals(pAgent, null))
			{
				foreach (uint key2 in target.m_variables.Keys)
				{
					IInstantiatedVariable instantiatedVariable2 = this.m_variables[key2];
					instantiatedVariable2.CopyTo(pAgent);
				}
			}
		}

		// Token: 0x0601AC41 RID: 109633 RVA: 0x0083C588 File Offset: 0x0083A988
		private void Save(ISerializableNode node)
		{
			CSerializationID chidlId = new CSerializationID("vars");
			ISerializableNode node2 = node.newChild(chidlId);
			foreach (IInstantiatedVariable instantiatedVariable in this.m_variables.Values)
			{
				instantiatedVariable.Save(node2);
			}
		}

		// Token: 0x1700229F RID: 8863
		// (get) Token: 0x0601AC42 RID: 109634 RVA: 0x0083C5D8 File Offset: 0x0083A9D8
		public Dictionary<uint, IInstantiatedVariable> Vars
		{
			get
			{
				return this.m_variables;
			}
		}

		// Token: 0x04012A27 RID: 76327
		protected Dictionary<uint, IInstantiatedVariable> m_variables = new Dictionary<uint, IInstantiatedVariable>();
	}
}
