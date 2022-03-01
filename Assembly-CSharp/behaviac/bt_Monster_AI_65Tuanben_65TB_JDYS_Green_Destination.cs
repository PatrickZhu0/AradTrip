using System;

namespace behaviac
{
	// Token: 0x02002BAB RID: 11179
	public static class bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination
	{
		// Token: 0x0601405E RID: 82014 RVA: 0x00603718 File Offset: 0x00601B18
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/65Tuanben/65TB_JDYS_Green_Destination");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(7);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(4);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node5 condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node = new Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node5();
			condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node.SetId(5);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node6 action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node = new Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node6();
			action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node.SetId(6);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(0);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node1 condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node2 = new Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node1();
			condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node2.SetId(1);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node2.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node2 action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node2 = new Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node2();
			action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node2.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node2.SetId(2);
			sequence2.AddChild(action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(3);
			selector.AddChild(sequence3);
			Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node8 action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node3 = new Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node8();
			action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node3.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node3.SetId(8);
			sequence3.AddChild(action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
