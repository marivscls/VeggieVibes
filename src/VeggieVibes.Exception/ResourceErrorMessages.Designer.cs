﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VeggieVibes.Exception
{
    using System;


    /// <summary>
    ///   Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    /// </summary>
    // Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    // através de uma ferramenta como ResGen ou Visual Studio.
    // Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    // com a opção /str, ou recrie o projeto do VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceErrorMessages
    {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public ResourceErrorMessages()
        {
        }

        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VeggieVibes.Exception.ResourceErrorMessages", typeof(ResourceErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        ///   Substitui a propriedade CurrentUICulture do thread atual para todas as
        ///   pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The calories per serving must be greater than zero.
        /// </summary>
        public static string CALORIES_POSITIVE
        {
            get
            {
                return ResourceManager.GetString("CALORIES_POSITIVE", resourceCulture);
            }
        }

        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The cooking time must be greater than zero.
        /// </summary>
        public static string COOKING_TIME_POSITIVE
        {
            get
            {
                return ResourceManager.GetString("COOKING_TIME_POSITIVE", resourceCulture);
            }
        }

        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The description must have a maximum of 500 characters.
        /// </summary>
        public static string DESCRIPTION_MAX_LENGTH
        {
            get
            {
                return ResourceManager.GetString("DESCRIPTION_MAX_LENGTH", resourceCulture);
            }
        }

        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The recipe description is required.
        /// </summary>
        public static string DESCRIPTION_REQUIRED
        {
            get
            {
                return ResourceManager.GetString("DESCRIPTION_REQUIRED", resourceCulture);
            }
        }

        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The recipe must have at least one ingredient.
        /// </summary>
        public static string INGREDIENTS_REQUIRED
        {
            get
            {
                return ResourceManager.GetString("INGREDIENTS_REQUIRED", resourceCulture);
            }
        }

        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The recipe must have at least one instruction.
        /// </summary>
        public static string INSTRUCTIONS_REQUIRED
        {
            get
            {
                return ResourceManager.GetString("INSTRUCTIONS_REQUIRED", resourceCulture);
            }
        }

        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The preparation time must be greater than zero.
        /// </summary>
        public static string PREPARATION_TIME_POSITIVE
        {
            get
            {
                return ResourceManager.GetString("PREPARATION_TIME_POSITIVE", resourceCulture);
            }
        }

        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Recipe not found.
        /// </summary>
        public static string RECIPE_NOT_FOUND
        {
            get
            {
                return ResourceManager.GetString("RECIPE_NOT_FOUND", resourceCulture);
            }
        }

        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The title must have a maximum of 100 characters.
        /// </summary>
        public static string TITLE_MAX_LENGTH
        {
            get
            {
                return ResourceManager.GetString("TITLE_MAX_LENGTH", resourceCulture);
            }
        }

        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a The recipe title is required.
        /// </summary>
        public static string TITLE_REQUIRED
        {
            get
            {
                return ResourceManager.GetString("TITLE_REQUIRED", resourceCulture);
            }
        }

        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Unknown error.
        /// </summary>
        public static string UNKNOWN_ERROR
        {
            get
            {
                return ResourceManager.GetString("UNKNOWN_ERROR", resourceCulture);
            }
        }

        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a user id required.
        /// </summary>
        public static string USER_ID_REQUIRED
        {
            get
            {
                return ResourceManager.GetString("USER_ID_REQUIRED", resourceCulture);
            }
        }
    }
}
