using System;

namespace behaviac
{
	// Token: 0x02002BCE RID: 11214
	public static class bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng
	{
		// Token: 0x0601409D RID: 82077 RVA: 0x00604C44 File Offset: 0x00603044
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/65Tuanben/65TB_Saiche_liucheng");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node0 action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node = new Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node0();
			action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node.SetId(0);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node2 action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node2 = new Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node2();
			action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node2.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node2.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node3 action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node3 = new Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node3();
			action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node3.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node3.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node3);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node3.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node4 action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node4 = new Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node4();
			action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node4.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node4.SetId(4);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node4);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_node4.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
