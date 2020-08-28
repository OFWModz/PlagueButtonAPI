using MelonLoader;
using System;
using UnityEngine;
using PlagueButtonAPI;

namespace PlagueButtonAPIExample
{
    public class PlagueButtonAPIExampleMain : MelonMod
    {
        public override void VRChat_OnUiManagerInit()
        {
            //Make Button To Enter SubMenu_1
            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "Utils", "Some Random Utils.", ButtonAPI.HorizontalPosition.LeftOfMenu, ButtonAPI.VerticalPosition.TopButton, null, delegate (bool a)
            {
                ButtonAPI.EnterSubMenu(ButtonAPI.MakeEmptyPage("SubMenu_1"));
            }, Color.white, Color.magenta, null, false, true, false, false, null, true);

            //SubMenu_1 Contents
            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "Next Page", "Goes To The Next Page.", ButtonAPI.HorizontalPosition.LeftOfMenu, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("SubMenu_1").transform, delegate (bool a)
            {
                ButtonAPI.EnterSubMenu(ButtonAPI.MakeEmptyPage("SubMenu_2"));
            }, Color.white, Color.magenta, null, false, true, false, false, null, true);

            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Toggle, "Toggle Pickups", "Toggles All Pickups In The Current Instance.", ButtonAPI.HorizontalPosition.FirstButtonPos, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("SubMenu_1").transform, delegate (bool a)
            {
                TogglePickups(a);
            }, Color.white, Color.magenta, null, false, true, false, false, null, true);

            //SubMenu_2 Contents
            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "Prev Page", "Goes To The Previous Page.", ButtonAPI.HorizontalPosition.LeftOfMenu, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("SubMenu_2").transform, delegate (bool a)
            {
                ButtonAPI.EnterSubMenu(ButtonAPI.MakeEmptyPage("SubMenu_1"));
            }, Color.white, Color.magenta, null, false, true, false, false, null, true);

            ButtonAPI.CreateButton(ButtonAPI.ButtonType.Default, "Hello World", "Prints Hello World To Console.", ButtonAPI.HorizontalPosition.FirstButtonPos, ButtonAPI.VerticalPosition.TopButton, ButtonAPI.MakeEmptyPage("SubMenu_2").transform, delegate (bool a)
            {
                MelonLogger.Log(ConsoleColor.Magenta, "Hello World!");
            }, Color.white, Color.magenta, null, false, true, false, false, null, true);
        }

        public static void TogglePickups(bool state)
        {
            var array = Resources.FindObjectsOfTypeAll<VRCSDK2.VRC_Pickup>();

            foreach (var i in array)
            {
                if (i == null)
                {
                    continue;
                }

                if (i.name.Contains("ViewFinder"))
                {
                    continue;
                }

                // ;)
                i.DisallowTheft = false;

                if (i.gameObject.active == !state)
                {
                    i.gameObject.SetActive(state);
                }
            }
        }

        /*//Example OnSpawn
        public enum NHDDDDJNDMB
        {
            Undefined,
            Loading,
            Error,
            Blocked,
            Safety,
            Substitute,
            Performance,
            Custom
        }

        public override void OnUpdate()
        {
            try
            {
                //If User Has Loaded A World
                if (RoomManagerBase.prop_Boolean_3)
                {
                    //Vital Null Check
                    if (VRCPlayer.field_Internal_Static_VRCPlayer_0 != null)
                    {
                        //If Avatar Has Loaded In
                        if (Enum.GetName(typeof(NHDDDDJNDMB), VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_VRCAvatarManager_0.prop_EnumNPublicSealedva9vUnique_0).Contains("Custom"))
                        {

                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MelonModLogger.Log("Error in OnUpdate! " + ex.Message + " in " + ex.Source + " Stack: " + ex.StackTrace);
            }
        }*/
    }
}
