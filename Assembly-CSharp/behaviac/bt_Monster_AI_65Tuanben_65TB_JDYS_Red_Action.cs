using System;

namespace behaviac
{
	// Token: 0x02002BB2 RID: 11186
	public static class bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action
	{
		// Token: 0x0601406B RID: 82027 RVA: 0x00603BF0 File Offset: 0x00601FF0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/65Tuanben/65TB_JDYS_Red_Action");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(7);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node3 condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node = new Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node3();
			condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node0 condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node2 = new Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node0();
			condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node2.SetId(0);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node2.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node2 action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node = new Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node2();
			action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(4);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node5 condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node3 = new Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node5();
			condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node3.SetId(5);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node3.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node8 condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node4 = new Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node8();
			condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node4.SetId(8);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node4.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node6 action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node2 = new Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node6();
			action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node2.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node2.SetId(6);
			sequence2.AddChild(action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
