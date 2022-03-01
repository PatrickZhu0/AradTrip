using System;

namespace behaviac
{
	// Token: 0x02003A17 RID: 14871
	public static class bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION
	{
		// Token: 0x06015BF9 RID: 89081 RVA: 0x00691B68 File Offset: 0x0068FF68
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/KexilaEmeng_GongmenChushou02_ACTION");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node17 condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node = new Condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node17();
			condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node.SetId(17);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node1 action_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node = new Action_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node1();
			action_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node.SetId(1);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou02_ACTION_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
