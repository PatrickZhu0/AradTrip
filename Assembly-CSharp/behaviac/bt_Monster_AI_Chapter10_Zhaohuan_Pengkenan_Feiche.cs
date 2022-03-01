using System;

namespace behaviac
{
	// Token: 0x0200315C RID: 12636
	public static class bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche
	{
		// Token: 0x06014B56 RID: 84822 RVA: 0x0063C948 File Offset: 0x0063AD48
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Chapter10/Zhaohuan_Pengkenan_Feiche");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node2 action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node = new Action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node2();
			action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node.HasEvents());
			Condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node3 condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node = new Condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node3();
			condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node.HasEvents());
			Action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node1 action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node2 = new Action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node1();
			action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node2.SetId(1);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
