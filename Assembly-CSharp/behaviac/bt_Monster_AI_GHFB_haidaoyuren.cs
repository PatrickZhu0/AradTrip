using System;

namespace behaviac
{
	// Token: 0x020032CA RID: 13002
	public static class bt_Monster_AI_GHFB_haidaoyuren
	{
		// Token: 0x06014E06 RID: 85510 RVA: 0x00649FEC File Offset: 0x006483EC
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/GHFB/haidaoyuren");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_GHFB_haidaoyuren_node3 condition_bt_Monster_AI_GHFB_haidaoyuren_node = new Condition_bt_Monster_AI_GHFB_haidaoyuren_node3();
			condition_bt_Monster_AI_GHFB_haidaoyuren_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_GHFB_haidaoyuren_node.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_GHFB_haidaoyuren_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_GHFB_haidaoyuren_node.HasEvents());
			Condition_bt_Monster_AI_GHFB_haidaoyuren_node1 condition_bt_Monster_AI_GHFB_haidaoyuren_node2 = new Condition_bt_Monster_AI_GHFB_haidaoyuren_node1();
			condition_bt_Monster_AI_GHFB_haidaoyuren_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_GHFB_haidaoyuren_node2.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_GHFB_haidaoyuren_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_GHFB_haidaoyuren_node2.HasEvents());
			Action_bt_Monster_AI_GHFB_haidaoyuren_node2 action_bt_Monster_AI_GHFB_haidaoyuren_node = new Action_bt_Monster_AI_GHFB_haidaoyuren_node2();
			action_bt_Monster_AI_GHFB_haidaoyuren_node.SetClassNameString("Action");
			action_bt_Monster_AI_GHFB_haidaoyuren_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_GHFB_haidaoyuren_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GHFB_haidaoyuren_node.HasEvents());
			Assignment_bt_Monster_AI_GHFB_haidaoyuren_node4 assignment_bt_Monster_AI_GHFB_haidaoyuren_node = new Assignment_bt_Monster_AI_GHFB_haidaoyuren_node4();
			assignment_bt_Monster_AI_GHFB_haidaoyuren_node.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_GHFB_haidaoyuren_node.SetId(4);
			sequence.AddChild(assignment_bt_Monster_AI_GHFB_haidaoyuren_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Monster_AI_GHFB_haidaoyuren_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
