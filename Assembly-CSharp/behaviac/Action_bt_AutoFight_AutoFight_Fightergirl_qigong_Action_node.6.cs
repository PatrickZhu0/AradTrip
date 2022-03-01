using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F0A RID: 7946
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node28 : Action
	{
		// Token: 0x060127B8 RID: 75704 RVA: 0x00568404 File Offset: 0x00566804
		public Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node28()
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
			item.skillID = 3113;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060127B9 RID: 75705 RVA: 0x00568494 File Offset: 0x00566894
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1AD RID: 49581
		private List<Input> method_p0;

		// Token: 0x0400C1AE RID: 49582
		private bool method_p1;
	}
}
