using System;

namespace behaviac
{
	// Token: 0x02003A14 RID: 14868
	public static class bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou01_ACTION
	{
		// Token: 0x06015BF4 RID: 89076 RVA: 0x006919AC File Offset: 0x0068FDAC
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/KexilaEmeng_GongmenChushou01_ACTION");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou01_ACTION_node17 condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou01_ACTION_node = new Condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou01_ACTION_node17();
			condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou01_ACTION_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou01_ACTION_node.SetId(17);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou01_ACTION_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou01_ACTION_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou01_ACTION_node1 action_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou01_ACTION_node = new Action_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou01_ACTION_node1();
			action_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou01_ACTION_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou01_ACTION_node.SetId(1);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou01_ACTION_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou01_ACTION_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
