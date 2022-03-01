using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using MiniXml;

namespace behaviac
{
	// Token: 0x02004849 RID: 18505
	public class BehaviorTree : BehaviorNode
	{
		// Token: 0x17002294 RID: 8852
		// (get) Token: 0x0601A9A8 RID: 108968 RVA: 0x00838683 File Offset: 0x00836A83
		public Dictionary<uint, ICustomizedProperty> LocalProps
		{
			get
			{
				return this.m_localProps;
			}
		}

		// Token: 0x0601A9A9 RID: 108969 RVA: 0x0083868B File Offset: 0x00836A8B
		public void AddPar(string agentType, string typeName, string name, string valueStr)
		{
			this.AddLocal(agentType, typeName, name, valueStr);
		}

		// Token: 0x0601A9AA RID: 108970 RVA: 0x00838698 File Offset: 0x00836A98
		public void AddLocal(string agentType, string typeName, string name, string valueStr)
		{
			if (this.m_localProps == null)
			{
				this.m_localProps = new Dictionary<uint, ICustomizedProperty>();
			}
			uint num = Utils.MakeVariableId(name);
			ICustomizedProperty value = AgentMeta.CreateProperty(typeName, num, name, valueStr);
			this.m_localProps[num] = value;
			Type elementTypeFromName = Utils.GetElementTypeFromName(typeName);
			if (elementTypeFromName != null)
			{
				typeName = Utils.GetNativeTypeName(elementTypeFromName);
				value = AgentMeta.CreateArrayItemProperty(typeName, num, name);
				num = Utils.MakeVariableId(name + "[]");
				this.m_localProps[num] = value;
			}
		}

		// Token: 0x0601A9AB RID: 108971 RVA: 0x00838718 File Offset: 0x00836B18
		public void InstantiatePars(Dictionary<uint, IInstantiatedVariable> vars)
		{
			if (this.m_localProps != null)
			{
				foreach (uint key in this.m_localProps.Keys)
				{
					vars[key] = this.m_localProps[key].Instantiate();
				}
			}
		}

		// Token: 0x0601A9AC RID: 108972 RVA: 0x00838774 File Offset: 0x00836B74
		public void UnInstantiatePars(Dictionary<uint, IInstantiatedVariable> vars)
		{
			if (this.m_localProps != null)
			{
				foreach (uint key in this.m_localProps.Keys)
				{
					vars.Remove(key);
				}
			}
		}

		// Token: 0x0601A9AD RID: 108973 RVA: 0x008387C0 File Offset: 0x00836BC0
		protected override void load_local(int version, string agentType, SecurityElement node)
		{
			if (node.Tag != "par")
			{
				return;
			}
			string name = node.Attribute("name");
			string typeName = node.Attribute("type").Replace("::", ".");
			string valueStr = node.Attribute("value");
			this.AddLocal(agentType, typeName, name, valueStr);
		}

		// Token: 0x0601A9AE RID: 108974 RVA: 0x00838820 File Offset: 0x00836C20
		protected override void load_local(int version, string agentType, BsonDeserizer d)
		{
			d.OpenDocument();
			string name = d.ReadString();
			string typeName = d.ReadString().Replace("::", ".");
			string valueStr = d.ReadString();
			this.AddLocal(agentType, typeName, name, valueStr);
			d.CloseDocument(true);
		}

		// Token: 0x0601A9AF RID: 108975 RVA: 0x0083886C File Offset: 0x00836C6C
		public bool load_xml(byte[] pBuffer)
		{
			try
			{
				string @string = Encoding.UTF8.GetString(pBuffer);
				SecurityParser securityParser = new SecurityParser();
				securityParser.LoadXml(@string);
				SecurityElement securityElement = securityParser.ToXml();
				if (securityElement.Tag != "behavior" && (securityElement.Children == null || securityElement.Children.Count != 1))
				{
					return false;
				}
				this.m_name = securityElement.Attribute("name");
				string agentType = securityElement.Attribute("agenttype").Replace("::", ".");
				string text = securityElement.Attribute("fsm");
				string s = securityElement.Attribute("version");
				int num = int.Parse(s);
				if (num != 5)
				{
				}
				base.SetClassNameString("BehaviorTree");
				base.SetId(-1);
				if (!string.IsNullOrEmpty(text) && text == "true")
				{
					this.m_bIsFSM = true;
				}
				base.load_properties_pars_attachments_children(true, num, agentType, securityElement);
				return true;
			}
			catch (Exception ex)
			{
			}
			return false;
		}

		// Token: 0x0601A9B0 RID: 108976 RVA: 0x0083898C File Offset: 0x00836D8C
		public bool load_bson(byte[] pBuffer)
		{
			try
			{
				BsonDeserizer bsonDeserizer = new BsonDeserizer();
				if (bsonDeserizer.Init(pBuffer))
				{
					BsonDeserizer.BsonTypes bsonTypes = bsonDeserizer.ReadType();
					if (bsonTypes == BsonDeserizer.BsonTypes.BT_BehaviorElement)
					{
						bool flag = bsonDeserizer.OpenDocument();
						this.m_name = bsonDeserizer.ReadString();
						string text = bsonDeserizer.ReadString();
						string agentType = text.Replace("::", ".");
						bool bIsFSM = bsonDeserizer.ReadBool();
						string value = bsonDeserizer.ReadString();
						int num = Convert.ToInt32(value);
						if (num != 5)
						{
						}
						base.SetClassNameString("BehaviorTree");
						base.SetId(-1);
						this.m_bIsFSM = bIsFSM;
						base.load_properties_pars_attachments_children(num, agentType, bsonDeserizer, false);
						bsonDeserizer.CloseDocument(false);
						return true;
					}
				}
			}
			catch (Exception ex)
			{
			}
			return false;
		}

		// Token: 0x0601A9B1 RID: 108977 RVA: 0x00838A5C File Offset: 0x00836E5C
		public string GetName()
		{
			return this.m_name;
		}

		// Token: 0x0601A9B2 RID: 108978 RVA: 0x00838A64 File Offset: 0x00836E64
		public void SetName(string name)
		{
			this.m_name = name;
		}

		// Token: 0x17002295 RID: 8853
		// (get) Token: 0x0601A9B3 RID: 108979 RVA: 0x00838A6D File Offset: 0x00836E6D
		// (set) Token: 0x0601A9B4 RID: 108980 RVA: 0x00838A75 File Offset: 0x00836E75
		public bool IsFSM
		{
			get
			{
				return this.m_bIsFSM;
			}
			set
			{
				this.m_bIsFSM = value;
			}
		}

		// Token: 0x0601A9B5 RID: 108981 RVA: 0x00838A80 File Offset: 0x00836E80
		protected override BehaviorTask createTask()
		{
			return new BehaviorTreeTask();
		}

		// Token: 0x040129A7 RID: 76199
		private const int SupportedVersion = 5;

		// Token: 0x040129A8 RID: 76200
		private Dictionary<uint, ICustomizedProperty> m_localProps;

		// Token: 0x040129A9 RID: 76201
		protected string m_name;

		// Token: 0x040129AA RID: 76202
		private bool m_bIsFSM;
	}
}
