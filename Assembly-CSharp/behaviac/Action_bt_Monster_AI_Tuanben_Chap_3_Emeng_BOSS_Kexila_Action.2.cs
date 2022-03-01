using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003841 RID: 14401
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node12 : Action
	{
		// Token: 0x06015868 RID: 88168 RVA: 0x0067EFF8 File Offset: 0x0067D3F8
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 21217;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015869 RID: 88169 RVA: 0x0067F088 File Offset: 0x0067D488
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F22A RID: 61994
		private List<Input> method_p0;

		// Token: 0x0400F22B RID: 61995
		private bool method_p1;
	}
}
