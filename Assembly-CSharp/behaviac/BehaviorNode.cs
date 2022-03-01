using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;

namespace behaviac
{
	// Token: 0x02004847 RID: 18503
	public abstract class BehaviorNode
	{
		// Token: 0x0601A974 RID: 108916 RVA: 0x0054EB00 File Offset: 0x0054CF00
		public BehaviorTask CreateAndInitTask()
		{
			BehaviorTask behaviorTask = this.createTask();
			behaviorTask.Init(this);
			return behaviorTask;
		}

		// Token: 0x0601A975 RID: 108917 RVA: 0x0054EB1C File Offset: 0x0054CF1C
		public bool HasEvents()
		{
			return this.m_bHasEvents;
		}

		// Token: 0x0601A976 RID: 108918 RVA: 0x0054EB24 File Offset: 0x0054CF24
		public void SetHasEvents(bool hasEvents)
		{
			this.m_bHasEvents = hasEvents;
		}

		// Token: 0x0601A977 RID: 108919 RVA: 0x0054EB2D File Offset: 0x0054CF2D
		public int GetChildrenCount()
		{
			if (this.m_children != null)
			{
				return this.m_children.Count;
			}
			return 0;
		}

		// Token: 0x0601A978 RID: 108920 RVA: 0x0054EB47 File Offset: 0x0054CF47
		public BehaviorNode GetChild(int index)
		{
			if (this.m_children != null && index < this.m_children.Count)
			{
				return this.m_children[index];
			}
			return null;
		}

		// Token: 0x0601A979 RID: 108921 RVA: 0x0054EB74 File Offset: 0x0054CF74
		public BehaviorNode GetChildById(int nodeId)
		{
			if (this.m_children != null && this.m_children.Count > 0)
			{
				for (int i = 0; i < this.m_children.Count; i++)
				{
					BehaviorNode behaviorNode = this.m_children[i];
					if (behaviorNode.GetId() == nodeId)
					{
						return behaviorNode;
					}
				}
			}
			return null;
		}

		// Token: 0x0601A97A RID: 108922 RVA: 0x0054EBD8 File Offset: 0x0054CFD8
		public void Clear()
		{
			if (this.m_events != null)
			{
				this.m_events.Clear();
				this.m_events = null;
			}
			if (this.m_preconditions != null)
			{
				this.m_preconditions.Clear();
				this.m_preconditions = null;
			}
			if (this.m_effectors != null)
			{
				this.m_effectors.Clear();
				this.m_effectors = null;
			}
			if (this.m_children != null)
			{
				this.m_children.Clear();
				this.m_children = null;
			}
		}

		// Token: 0x0601A97B RID: 108923 RVA: 0x0054EC59 File Offset: 0x0054D059
		public virtual bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return true;
		}

		// Token: 0x0601A97C RID: 108924 RVA: 0x0054EC5C File Offset: 0x0054D05C
		public virtual bool IsManagingChildrenAsSubTrees()
		{
			return false;
		}

		// Token: 0x0601A97D RID: 108925 RVA: 0x0054EC5F File Offset: 0x0054D05F
		protected static BehaviorNode Create(string className)
		{
			return Workspace.Instance.CreateBehaviorNode(className);
		}

		// Token: 0x0601A97E RID: 108926 RVA: 0x0054EC6C File Offset: 0x0054D06C
		protected virtual void load(int version, string agentType, List<property_t> properties)
		{
			string nodeType = this.GetClassNameString().Replace(".", "::");
			Workspace.Instance.OnBehaviorNodeLoaded(nodeType, properties);
		}

		// Token: 0x0601A97F RID: 108927 RVA: 0x0054EC9B File Offset: 0x0054D09B
		protected virtual void load_local(int version, string agentType, SecurityElement node)
		{
		}

		// Token: 0x0601A980 RID: 108928 RVA: 0x0054ECA0 File Offset: 0x0054D0A0
		protected void load_properties_pars_attachments_children(bool bNode, int version, string agentType, SecurityElement node)
		{
			bool flag = this.HasEvents();
			if (node.Children != null)
			{
				List<property_t> list = new List<property_t>();
				IEnumerator enumerator = node.Children.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						SecurityElement securityElement = (SecurityElement)obj;
						if (!this.load_property_pars(ref list, securityElement, version, agentType))
						{
							if (bNode)
							{
								if (securityElement.Tag == "attachment")
								{
									flag = this.load_attachment(version, agentType, flag, securityElement);
								}
								else if (securityElement.Tag == "custom")
								{
									SecurityElement node2 = (SecurityElement)securityElement.Children[0];
									BehaviorNode customCondition = BehaviorNode.load(agentType, node2, version);
									this.m_customCondition = customCondition;
								}
								else if (securityElement.Tag == "node")
								{
									BehaviorNode behaviorNode = BehaviorNode.load(agentType, securityElement, version);
									flag |= behaviorNode.m_bHasEvents;
									this.AddChild(behaviorNode);
								}
							}
							else if (securityElement.Tag == "attachment")
							{
								flag = this.load_attachment(version, agentType, flag, securityElement);
							}
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
				if (list.Count > 0)
				{
					this.load(version, agentType, list);
				}
			}
			this.m_bHasEvents = (this.m_bHasEvents || flag);
		}

		// Token: 0x0601A981 RID: 108929 RVA: 0x0054EE14 File Offset: 0x0054D214
		private void load_attachment_transition_effectors(int version, string agentType, bool bHasEvents, SecurityElement c)
		{
			this.m_loadAttachment = true;
			this.load_properties_pars_attachments_children(false, version, agentType, c);
			this.m_loadAttachment = false;
		}

		// Token: 0x0601A982 RID: 108930 RVA: 0x0054EE30 File Offset: 0x0054D230
		private bool load_attachment(int version, string agentType, bool bHasEvents, SecurityElement c)
		{
			try
			{
				string text = c.Attribute("class");
				if (text == null)
				{
					this.load_attachment_transition_effectors(version, agentType, bHasEvents, c);
					return true;
				}
				BehaviorNode behaviorNode = BehaviorNode.Create(text);
				if (behaviorNode != null)
				{
					behaviorNode.SetClassNameString(text);
					string value = c.Attribute("id");
					behaviorNode.SetId(Convert.ToInt32(value));
					bool bIsPrecondition = false;
					bool bIsEffector = false;
					bool bIsTransition = false;
					string a = c.Attribute("flag");
					if (a == "precondition")
					{
						bIsPrecondition = true;
					}
					else if (a == "effector")
					{
						bIsEffector = true;
					}
					else if (a == "transition")
					{
						bIsTransition = true;
					}
					behaviorNode.load_properties_pars_attachments_children(false, version, agentType, c);
					this.Attach(behaviorNode, bIsPrecondition, bIsEffector, bIsTransition);
					bHasEvents |= (behaviorNode is Event);
				}
				return bHasEvents;
			}
			catch (Exception ex)
			{
			}
			return bHasEvents;
		}

		// Token: 0x0601A983 RID: 108931 RVA: 0x0054EF34 File Offset: 0x0054D334
		private bool load_property_pars(ref List<property_t> properties, SecurityElement c, int version, string agentType)
		{
			try
			{
				if (c.Tag == "property")
				{
					IEnumerator enumerator = c.Attributes.Keys.GetEnumerator();
					try
					{
						if (enumerator.MoveNext())
						{
							string text = (string)enumerator.Current;
							string v = (string)c.Attributes[text];
							property_t item = new property_t(text, v);
							properties.Add(item);
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
					return true;
				}
				if (c.Tag == "pars")
				{
					if (c.Children != null)
					{
						IEnumerator enumerator2 = c.Children.GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								object obj = enumerator2.Current;
								SecurityElement securityElement = (SecurityElement)obj;
								if (securityElement.Tag == "par")
								{
									this.load_local(version, agentType, securityElement);
								}
							}
						}
						finally
						{
							IDisposable disposable2;
							if ((disposable2 = (enumerator2 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					return true;
				}
			}
			catch (Exception ex)
			{
			}
			return false;
		}

		// Token: 0x0601A984 RID: 108932 RVA: 0x0054F0BC File Offset: 0x0054D4BC
		protected static BehaviorNode load(string agentType, SecurityElement node, int version)
		{
			string text = node.Attribute("class");
			BehaviorNode behaviorNode = BehaviorNode.Create(text);
			if (behaviorNode != null)
			{
				behaviorNode.SetClassNameString(text);
				string value = node.Attribute("id");
				behaviorNode.SetId(Convert.ToInt32(value));
				behaviorNode.load_properties_pars_attachments_children(true, version, agentType, node);
			}
			return behaviorNode;
		}

		// Token: 0x0601A985 RID: 108933 RVA: 0x0054F10C File Offset: 0x0054D50C
		protected void load_properties(int version, string agentType, BsonDeserizer d)
		{
			d.OpenDocument();
			List<property_t> list = new List<property_t>();
			for (BsonDeserizer.BsonTypes bsonTypes = d.ReadType(); bsonTypes == BsonDeserizer.BsonTypes.BT_String; bsonTypes = d.ReadType())
			{
				string n = d.ReadString();
				string v = d.ReadString();
				list.Add(new property_t(n, v));
			}
			if (list.Count > 0)
			{
				this.load(version, agentType, list);
			}
			d.CloseDocument(false);
		}

		// Token: 0x0601A986 RID: 108934 RVA: 0x0054F178 File Offset: 0x0054D578
		protected void load_locals(int version, string agentType, BsonDeserizer d)
		{
			d.OpenDocument();
			for (BsonDeserizer.BsonTypes bsonTypes = d.ReadType(); bsonTypes == BsonDeserizer.BsonTypes.BT_ParElement; bsonTypes = d.ReadType())
			{
				this.load_local(version, agentType, d);
			}
			d.CloseDocument(false);
		}

		// Token: 0x0601A987 RID: 108935 RVA: 0x0054F1B8 File Offset: 0x0054D5B8
		protected void load_children(int version, string agentType, BsonDeserizer d)
		{
			d.OpenDocument();
			BehaviorNode behaviorNode = this.load(agentType, d, version);
			bool bHasEvents = behaviorNode.m_bHasEvents;
			this.AddChild(behaviorNode);
			this.m_bHasEvents = (this.m_bHasEvents || bHasEvents);
			d.CloseDocument(false);
		}

		// Token: 0x0601A988 RID: 108936 RVA: 0x0054F1FC File Offset: 0x0054D5FC
		protected void load_custom(int version, string agentType, BsonDeserizer d)
		{
			d.OpenDocument();
			BsonDeserizer.BsonTypes bsonTypes = d.ReadType();
			d.OpenDocument();
			BehaviorNode customCondition = this.load(agentType, d, version);
			this.m_customCondition = customCondition;
			d.CloseDocument(false);
			d.CloseDocument(false);
			bsonTypes = d.ReadType();
		}

		// Token: 0x0601A989 RID: 108937 RVA: 0x0054F244 File Offset: 0x0054D644
		protected void load_properties_pars_attachments_children(int version, string agentType, BsonDeserizer d, bool bIsTransition)
		{
			for (BsonDeserizer.BsonTypes bsonTypes = d.ReadType(); bsonTypes != BsonDeserizer.BsonTypes.BT_None; bsonTypes = d.ReadType())
			{
				if (bsonTypes == BsonDeserizer.BsonTypes.BT_PropertiesElement)
				{
					try
					{
						this.load_properties(version, agentType, d);
					}
					catch (Exception ex)
					{
					}
				}
				else if (bsonTypes == BsonDeserizer.BsonTypes.BT_ParsElement)
				{
					this.load_locals(version, agentType, d);
				}
				else if (bsonTypes == BsonDeserizer.BsonTypes.BT_AttachmentsElement)
				{
					this.load_attachments(version, agentType, d, bIsTransition);
					this.m_bHasEvents |= this.HasEvents();
				}
				else if (bsonTypes == BsonDeserizer.BsonTypes.BT_Custom)
				{
					this.load_custom(version, agentType, d);
				}
				else if (bsonTypes == BsonDeserizer.BsonTypes.BT_NodeElement)
				{
					this.load_children(version, agentType, d);
				}
			}
		}

		// Token: 0x0601A98A RID: 108938 RVA: 0x0054F308 File Offset: 0x0054D708
		protected BehaviorNode load(string agentType, BsonDeserizer d, int version)
		{
			string text = d.ReadString();
			BehaviorNode behaviorNode = BehaviorNode.Create(text);
			if (behaviorNode != null)
			{
				behaviorNode.SetClassNameString(text);
				string value = d.ReadString();
				behaviorNode.SetId(Convert.ToInt32(value));
				behaviorNode.load_properties_pars_attachments_children(version, agentType, d, false);
			}
			return behaviorNode;
		}

		// Token: 0x0601A98B RID: 108939 RVA: 0x0054F34E File Offset: 0x0054D74E
		protected virtual void load_local(int version, string agentType, BsonDeserizer d)
		{
		}

		// Token: 0x0601A98C RID: 108940 RVA: 0x0054F350 File Offset: 0x0054D750
		protected void load_attachments(int version, string agentType, BsonDeserizer d, bool bIsTransition)
		{
			d.OpenDocument();
			BsonDeserizer.BsonTypes bsonTypes;
			for (bsonTypes = d.ReadType(); bsonTypes == BsonDeserizer.BsonTypes.BT_AttachmentElement; bsonTypes = d.ReadType())
			{
				d.OpenDocument();
				if (bIsTransition)
				{
					this.m_loadAttachment = true;
					this.load_properties_pars_attachments_children(version, agentType, d, false);
					this.m_loadAttachment = false;
				}
				else
				{
					string text = d.ReadString();
					BehaviorNode behaviorNode = BehaviorNode.Create(text);
					if (behaviorNode != null)
					{
						behaviorNode.SetClassNameString(text);
						string value = d.ReadString();
						behaviorNode.SetId(Convert.ToInt32(value));
						bool bIsPrecondition = d.ReadBool();
						bool bIsEffector = d.ReadBool();
						bool bIsTransition2 = d.ReadBool();
						behaviorNode.load_properties_pars_attachments_children(version, agentType, d, bIsTransition2);
						this.Attach(behaviorNode, bIsPrecondition, bIsEffector, bIsTransition2);
						this.m_bHasEvents |= (behaviorNode is Event);
					}
				}
				d.CloseDocument(false);
			}
			if (bsonTypes != BsonDeserizer.BsonTypes.BT_None)
			{
				if (bsonTypes == BsonDeserizer.BsonTypes.BT_ParsElement)
				{
					this.load_locals(version, agentType, d);
				}
				else if (bsonTypes == BsonDeserizer.BsonTypes.BT_AttachmentsElement)
				{
					this.load_attachments(version, agentType, d, bIsTransition);
					this.m_bHasEvents |= this.HasEvents();
				}
				bsonTypes = d.ReadType();
			}
			d.CloseDocument(false);
		}

		// Token: 0x0601A98D RID: 108941 RVA: 0x0054F47C File Offset: 0x0054D87C
		protected BehaviorNode load_node(int version, string agentType, BsonDeserizer d)
		{
			d.OpenDocument();
			BsonDeserizer.BsonTypes bsonTypes = d.ReadType();
			d.OpenDocument();
			BehaviorNode result = this.load(agentType, d, version);
			d.CloseDocument(false);
			bsonTypes = d.ReadType();
			d.CloseDocument(false);
			return result;
		}

		// Token: 0x0601A98E RID: 108942 RVA: 0x0054F4BE File Offset: 0x0054D8BE
		public void Attach(BehaviorNode pAttachment, bool bIsPrecondition, bool bIsEffector)
		{
			this.Attach(pAttachment, bIsPrecondition, bIsEffector, false);
		}

		// Token: 0x0601A98F RID: 108943 RVA: 0x0054F4CC File Offset: 0x0054D8CC
		public virtual void Attach(BehaviorNode pAttachment, bool bIsPrecondition, bool bIsEffector, bool bIsTransition)
		{
			if (bIsPrecondition)
			{
				if (this.m_preconditions == null)
				{
					this.m_preconditions = new List<Precondition>();
				}
				Precondition precondition = pAttachment as Precondition;
				this.m_preconditions.Add(precondition);
				Precondition.EPhase phase = precondition.Phase;
				if (phase == Precondition.EPhase.E_ENTER)
				{
					this.m_enter_precond += 1;
				}
				else if (phase == Precondition.EPhase.E_UPDATE)
				{
					this.m_update_precond += 1;
				}
				else if (phase == Precondition.EPhase.E_BOTH)
				{
					this.m_both_precond += 1;
				}
			}
			else if (bIsEffector)
			{
				if (this.m_effectors == null)
				{
					this.m_effectors = new List<Effector>();
				}
				Effector effector = pAttachment as Effector;
				this.m_effectors.Add(effector);
				Effector.EPhase phase2 = effector.Phase;
				if (phase2 == Effector.EPhase.E_SUCCESS)
				{
					this.m_success_effectors += 1;
				}
				else if (phase2 == Effector.EPhase.E_FAILURE)
				{
					this.m_failure_effectors += 1;
				}
				else if (phase2 == Effector.EPhase.E_BOTH)
				{
					this.m_both_effectors += 1;
				}
			}
			else
			{
				if (this.m_events == null)
				{
					this.m_events = new List<BehaviorNode>();
				}
				this.m_events.Add(pAttachment);
			}
		}

		// Token: 0x0601A990 RID: 108944 RVA: 0x0054F611 File Offset: 0x0054DA11
		public virtual void AddChild(BehaviorNode pChild)
		{
			pChild.m_parent = this;
			if (this.m_children == null)
			{
				this.m_children = new List<BehaviorNode>();
			}
			this.m_children.Add(pChild);
		}

		// Token: 0x0601A991 RID: 108945 RVA: 0x0054F63C File Offset: 0x0054DA3C
		protected virtual EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return EBTStatus.BT_FAILURE;
		}

		// Token: 0x0601A992 RID: 108946 RVA: 0x0054F63F File Offset: 0x0054DA3F
		public void SetClassNameString(string className)
		{
			this.m_className = className;
		}

		// Token: 0x0601A993 RID: 108947 RVA: 0x0054F648 File Offset: 0x0054DA48
		public string GetClassNameString()
		{
			return this.m_className;
		}

		// Token: 0x0601A994 RID: 108948 RVA: 0x0054F650 File Offset: 0x0054DA50
		public int GetId()
		{
			return this.m_id;
		}

		// Token: 0x0601A995 RID: 108949 RVA: 0x0054F658 File Offset: 0x0054DA58
		public void SetId(int id)
		{
			this.m_id = id;
		}

		// Token: 0x0601A996 RID: 108950 RVA: 0x0054F661 File Offset: 0x0054DA61
		public string GetPath()
		{
			return string.Empty;
		}

		// Token: 0x17002292 RID: 8850
		// (get) Token: 0x0601A997 RID: 108951 RVA: 0x0054F668 File Offset: 0x0054DA68
		public BehaviorNode Parent
		{
			get
			{
				return this.m_parent;
			}
		}

		// Token: 0x17002293 RID: 8851
		// (get) Token: 0x0601A998 RID: 108952 RVA: 0x0054F670 File Offset: 0x0054DA70
		public int PreconditionsCount
		{
			get
			{
				if (this.m_preconditions != null)
				{
					return this.m_preconditions.Count;
				}
				return 0;
			}
		}

		// Token: 0x0601A999 RID: 108953 RVA: 0x0054F68C File Offset: 0x0054DA8C
		public bool CheckPreconditions(Agent pAgent, bool bIsAlive)
		{
			Precondition.EPhase ephase = (!bIsAlive) ? Precondition.EPhase.E_ENTER : Precondition.EPhase.E_UPDATE;
			if (this.m_preconditions == null || this.m_preconditions.Count == 0)
			{
				return true;
			}
			if (this.m_both_precond == 0)
			{
				if (ephase == Precondition.EPhase.E_ENTER && this.m_enter_precond == 0)
				{
					return true;
				}
				if (ephase == Precondition.EPhase.E_UPDATE && this.m_update_precond == 0)
				{
					return true;
				}
			}
			bool flag = true;
			bool result = false;
			for (int i = 0; i < this.m_preconditions.Count; i++)
			{
				Precondition precondition = this.m_preconditions[i];
				if (precondition != null)
				{
					Precondition.EPhase phase = precondition.Phase;
					if (ephase == Precondition.EPhase.E_BOTH || phase == Precondition.EPhase.E_BOTH || phase == ephase)
					{
						bool taskBoolean = precondition.Evaluate(pAgent);
						BehaviorNode.CombineResults(ref flag, ref result, precondition, taskBoolean);
					}
				}
			}
			return result;
		}

		// Token: 0x0601A99A RID: 108954 RVA: 0x0054F764 File Offset: 0x0054DB64
		private static void CombineResults(ref bool firstValidPrecond, ref bool lastCombineValue, Precondition pPrecond, bool taskBoolean)
		{
			if (firstValidPrecond)
			{
				firstValidPrecond = false;
				lastCombineValue = taskBoolean;
			}
			else
			{
				bool isAnd = pPrecond.IsAnd;
				if (isAnd)
				{
					lastCombineValue = (lastCombineValue && taskBoolean);
				}
				else
				{
					lastCombineValue = (lastCombineValue || taskBoolean);
				}
			}
		}

		// Token: 0x0601A99B RID: 108955 RVA: 0x0054F7B0 File Offset: 0x0054DBB0
		public virtual void ApplyEffects(Agent pAgent, Effector.EPhase phase)
		{
			if (this.m_effectors == null || this.m_effectors.Count == 0)
			{
				return;
			}
			if (this.m_both_effectors == 0)
			{
				if (phase == Effector.EPhase.E_SUCCESS && this.m_success_effectors == 0)
				{
					return;
				}
				if (phase == Effector.EPhase.E_FAILURE && this.m_failure_effectors == 0)
				{
					return;
				}
			}
			for (int i = 0; i < this.m_effectors.Count; i++)
			{
				Effector effector = this.m_effectors[i];
				if (effector != null)
				{
					Effector.EPhase phase2 = effector.Phase;
					if (phase == Effector.EPhase.E_BOTH || phase2 == Effector.EPhase.E_BOTH || phase2 == phase)
					{
						effector.Evaluate(pAgent);
					}
				}
			}
		}

		// Token: 0x0601A99C RID: 108956 RVA: 0x0054F85C File Offset: 0x0054DC5C
		public bool CheckEvents(string eventName, Agent pAgent, Dictionary<uint, IInstantiatedVariable> eventParams)
		{
			if (this.m_events != null)
			{
				for (int i = 0; i < this.m_events.Count; i++)
				{
					BehaviorNode behaviorNode = this.m_events[i];
					Event @event = behaviorNode as Event;
					if (@event != null && !string.IsNullOrEmpty(eventName))
					{
						string eventName2 = @event.GetEventName();
						if (!string.IsNullOrEmpty(eventName2) && eventName2 == eventName)
						{
							@event.switchTo(pAgent, eventParams);
							if (@event.TriggeredOnce())
							{
								return false;
							}
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0601A99D RID: 108957 RVA: 0x0054F8E9 File Offset: 0x0054DCE9
		public virtual bool Evaluate(Agent pAgent)
		{
			return false;
		}

		// Token: 0x0601A99E RID: 108958 RVA: 0x0054F8EC File Offset: 0x0054DCEC
		protected bool EvaluteCustomCondition(Agent pAgent)
		{
			return this.m_customCondition != null && this.m_customCondition.Evaluate(pAgent);
		}

		// Token: 0x0601A99F RID: 108959 RVA: 0x0054F907 File Offset: 0x0054DD07
		public void SetCustomCondition(BehaviorNode node)
		{
			this.m_customCondition = node;
		}

		// Token: 0x0601A9A0 RID: 108960
		protected abstract BehaviorTask createTask();

		// Token: 0x0601A9A1 RID: 108961 RVA: 0x0054F910 File Offset: 0x0054DD10
		public virtual bool enteraction_impl(Agent pAgent)
		{
			return false;
		}

		// Token: 0x0601A9A2 RID: 108962 RVA: 0x0054F913 File Offset: 0x0054DD13
		public virtual bool exitaction_impl(Agent pAgent)
		{
			return false;
		}

		// Token: 0x04012996 RID: 76182
		private string m_className;

		// Token: 0x04012997 RID: 76183
		private int m_id;

		// Token: 0x04012998 RID: 76184
		protected List<BehaviorNode> m_events;

		// Token: 0x04012999 RID: 76185
		private List<Precondition> m_preconditions;

		// Token: 0x0401299A RID: 76186
		private List<Effector> m_effectors;

		// Token: 0x0401299B RID: 76187
		protected bool m_loadAttachment;

		// Token: 0x0401299C RID: 76188
		private byte m_enter_precond;

		// Token: 0x0401299D RID: 76189
		private byte m_update_precond;

		// Token: 0x0401299E RID: 76190
		private byte m_both_precond;

		// Token: 0x0401299F RID: 76191
		private byte m_success_effectors;

		// Token: 0x040129A0 RID: 76192
		private byte m_failure_effectors;

		// Token: 0x040129A1 RID: 76193
		private byte m_both_effectors;

		// Token: 0x040129A2 RID: 76194
		protected BehaviorNode m_parent;

		// Token: 0x040129A3 RID: 76195
		protected List<BehaviorNode> m_children;

		// Token: 0x040129A4 RID: 76196
		protected BehaviorNode m_customCondition;

		// Token: 0x040129A5 RID: 76197
		protected bool m_bHasEvents;
	}
}
