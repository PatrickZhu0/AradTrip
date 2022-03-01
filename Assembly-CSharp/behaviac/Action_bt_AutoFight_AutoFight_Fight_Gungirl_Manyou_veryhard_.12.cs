using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002079 RID: 8313
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node30 : Action
	{
		// Token: 0x06012A8B RID: 76427 RVA: 0x00579768 File Offset: 0x00577B68
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node30()
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
			item.skillID = 2510;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012A8C RID: 76428 RVA: 0x005797F8 File Offset: 0x00577BF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C47E RID: 50302
		private List<Input> method_p0;

		// Token: 0x0400C47F RID: 50303
		private bool method_p1;
	}
}
