using System;

namespace behaviac
{
	// Token: 0x02002AF2 RID: 10994
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_node40 : Action
	{
		// Token: 0x06013EF8 RID: 81656 RVA: 0x005FC163 File Offset: 0x005FA563
		public Action_bt_Level_Tuanben_TuanBen_Wind_node40()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "Sound/Dungeon/boss_Tuanben_tongyong.ogg";
		}

		// Token: 0x06013EF9 RID: 81657 RVA: 0x005FC17D File Offset: 0x005FA57D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_PlayBgm(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D94F RID: 55631
		private string method_p0;
	}
}
