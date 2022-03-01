using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200385A RID: 14426
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node39 : Action
	{
		// Token: 0x0601589A RID: 88218 RVA: 0x0067F9D8 File Offset: 0x0067DDD8
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node39()
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
			item.skillID = 21213;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601589B RID: 88219 RVA: 0x0067FA68 File Offset: 0x0067DE68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F24D RID: 62029
		private List<Input> method_p0;

		// Token: 0x0400F24E RID: 62030
		private bool method_p1;
	}
}
