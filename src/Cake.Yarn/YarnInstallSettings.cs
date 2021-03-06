using Cake.Core;
using Cake.Core.IO;

namespace Cake.Yarn
{
    /// <summary>
    /// Yarn install options
    /// </summary>
    public class YarnInstallSettings : YarnRunnerSettings
    {
        /// <summary>
        /// Yarn "install" settings
        /// </summary>
        public YarnInstallSettings() : base("install")
        {
        }

        /// <summary>
        /// Evaluate options
        /// </summary>
        /// <param name="args"></param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (Production)
            {
                args.Append("--production");
            }

            if (IgnorePlatform)
            {
                args.Append("--ignore-platform");
            }

            if (IgnoreOptional)
            {
                args.Append("--ignore-optional");
            }
        }

        /// <summary>
        /// Applies the --production parameter (can not be set when installing individual packages
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public YarnInstallSettings ForProduction(bool enabled = true)
        {
            Production = enabled;
            return this;
        }

        /// <summary>
        /// Applies the --ignore-platform parameter
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public YarnInstallSettings IgnorePlatformWarnings(bool enabled = true)
        {
            IgnorePlatform = enabled;
            return this;
        }

        /// <summary>
        /// Applies the --ignore-optional parameter
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public YarnInstallSettings IgnoreOptionalWarnings(bool enabled = true)
        {
            IgnoreOptional = enabled;
            return this;
        }

        /// <summary>
        /// --production
        /// </summary>
        public bool Production { get; internal set; }

        /// <summary>
        /// --ignore-platform
        /// </summary>
        public bool IgnorePlatform { get; internal set; }

        /// <summary>
        /// --ignore-optional
        /// </summary>
        public bool IgnoreOptional { get; internal set; }
    }
}
