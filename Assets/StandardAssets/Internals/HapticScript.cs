using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StandardAssets;
#if S
using MoreMountains.NiceVibrations;


namespace StandardAssets
{
    public partial class SA
    {
        static partial void Haptic(HapticTypes haptic)
        {
            if (!SA.Settings.otherSettings.haptics)
            {
                return;
            }

            if (!MMVibrationManager.HapticsSupported())
            {
                return;
            }

            switch (haptic)
            {
                case HapticTypes.Selection:
                    MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.Selection);

                    break;
                case HapticTypes.Success:
                    MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.Success);

                    break;
                case HapticTypes.Warning:
                    MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.Warning);

                    break;
                case HapticTypes.Failure:
                    MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.Failure);

                    break;
                case HapticTypes.LightImpact:
                    MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.LightImpact);

                    break;
                case HapticTypes.MediumImpact:
                    MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

                    break;
                case HapticTypes.HeavyImpact:
                    MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.HeavyImpact);

                    break;
                case HapticTypes.RigidImpact:
                    MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.RigidImpact);

                    break;
                case HapticTypes.SoftImpact:
                    MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.SoftImpact);

                    break;
                case HapticTypes.None:
                    MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.None);
                    break;
                default:
                    MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.None);
                    break;

            }
        }
    }
}
#endif