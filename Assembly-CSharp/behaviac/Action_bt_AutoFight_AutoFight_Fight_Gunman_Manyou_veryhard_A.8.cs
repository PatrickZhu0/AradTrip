using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020021B1 RID: 8625
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node20 : Action
	{
		// Token: 0x06012CF1 RID: 77041 RVA: 0x00588828 File Offset: 0x00586C28
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node20()
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
			item.skillID = 1007;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012CF2 RID: 77042 RVA: 0x005888B8 File Offset: 0x00586CB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6E4 RID: 50916
		private List<Input> method_p0;

		// Token: 0x0400C6E5 RID: 50917
		private bool method_p1;
	}
}
