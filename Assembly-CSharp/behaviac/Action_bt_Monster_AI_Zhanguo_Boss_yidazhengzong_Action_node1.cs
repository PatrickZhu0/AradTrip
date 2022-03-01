using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E7F RID: 15999
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node12 : Action
	{
		// Token: 0x0601647F RID: 91263 RVA: 0x006BCA1C File Offset: 0x006BAE1C
		public Action_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 2;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 7284;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 1400;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 7285;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06016480 RID: 91264 RVA: 0x006BCB08 File Offset: 0x006BAF08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCB6 RID: 64694
		private List<Input> method_p0;

		// Token: 0x0400FCB7 RID: 64695
		private bool method_p1;
	}
}
