using System;

namespace behaviac
{
	// Token: 0x02003160 RID: 12640
	public static class bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan
	{
		// Token: 0x06014B5D RID: 84829 RVA: 0x0063CB80 File Offset: 0x0063AF80
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Chapter10/Zhaohuan_Pengkenan_Feiche_Fan");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node2 action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node = new Action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node2();
			action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node.HasEvents());
			Condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node3 condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node = new Condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node3();
			condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node.HasEvents());
			Action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node1 action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node2 = new Action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node1();
			action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node2.SetId(1);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
