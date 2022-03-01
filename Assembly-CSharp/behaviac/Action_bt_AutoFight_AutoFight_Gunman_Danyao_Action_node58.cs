using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020025B0 RID: 9648
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node58 : Action
	{
		// Token: 0x060134A7 RID: 79015 RVA: 0x005BC770 File Offset: 0x005BAB70
		public Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node58()
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
			item.skillID = 1204;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060134A8 RID: 79016 RVA: 0x005BC800 File Offset: 0x005BAC00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEDB RID: 52955
		private List<Input> method_p0;

		// Token: 0x0400CEDC RID: 52956
		private bool method_p1;
	}
}
