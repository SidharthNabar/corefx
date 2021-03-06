﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Linq;
using System.Diagnostics;


namespace System.Runtime.Serialization
{
    /// <SecurityNote>
    /// Critical - Class holds static instances used in serializer. 
    ///            Static fields are marked SecurityCritical or readonly to prevent
    ///            data from being modified or leaked to other components in appdomain.
    /// Safe - All get-only properties marked safe since they only need to be protected for write.
    /// </SecurityNote>
    internal static class Globals
    {
        /// <SecurityNote>
        /// Review - changes to const could affect code generation logic; any changes should be reviewed.
        /// </SecurityNote>
        internal const BindingFlags ScanAllMembers = BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        [SecurityCritical]
        private static XmlQualifiedName s_idQualifiedName;
        internal static XmlQualifiedName IdQualifiedName
        {
            [SecuritySafeCritical]
            get
            {
                if (s_idQualifiedName == null)
                    s_idQualifiedName = new XmlQualifiedName(Globals.IdLocalName, Globals.SerializationNamespace);
                return s_idQualifiedName;
            }
        }

        [SecurityCritical]
        private static XmlQualifiedName s_refQualifiedName;
        internal static XmlQualifiedName RefQualifiedName
        {
            [SecuritySafeCritical]
            get
            {
                if (s_refQualifiedName == null)
                    s_refQualifiedName = new XmlQualifiedName(Globals.RefLocalName, Globals.SerializationNamespace);
                return s_refQualifiedName;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfObject;
        internal static Type TypeOfObject
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfObject == null)
                    s_typeOfObject = typeof(object);
                return s_typeOfObject;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfValueType;
        internal static Type TypeOfValueType
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfValueType == null)
                    s_typeOfValueType = typeof(ValueType);
                return s_typeOfValueType;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfArray;
        internal static Type TypeOfArray
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfArray == null)
                    s_typeOfArray = typeof(Array);
                return s_typeOfArray;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfException;
        internal static Type TypeOfException
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfException == null)
                    s_typeOfException = typeof(Exception);
                return s_typeOfException;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfString;
        internal static Type TypeOfString
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfString == null)
                    s_typeOfString = typeof(string);
                return s_typeOfString;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfInt;
        internal static Type TypeOfInt
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfInt == null)
                    s_typeOfInt = typeof(int);
                return s_typeOfInt;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfULong;
        internal static Type TypeOfULong
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfULong == null)
                    s_typeOfULong = typeof(ulong);
                return s_typeOfULong;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfVoid;
        internal static Type TypeOfVoid
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfVoid == null)
                    s_typeOfVoid = typeof(void);
                return s_typeOfVoid;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfByteArray;
        internal static Type TypeOfByteArray
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfByteArray == null)
                    s_typeOfByteArray = typeof(byte[]);
                return s_typeOfByteArray;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfTimeSpan;
        internal static Type TypeOfTimeSpan
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfTimeSpan == null)
                    s_typeOfTimeSpan = typeof(TimeSpan);
                return s_typeOfTimeSpan;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfGuid;
        internal static Type TypeOfGuid
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfGuid == null)
                    s_typeOfGuid = typeof(Guid);
                return s_typeOfGuid;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfDateTimeOffset;
        internal static Type TypeOfDateTimeOffset
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfDateTimeOffset == null)
                    s_typeOfDateTimeOffset = typeof(DateTimeOffset);
                return s_typeOfDateTimeOffset;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfDateTimeOffsetAdapter;
        internal static Type TypeOfDateTimeOffsetAdapter
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfDateTimeOffsetAdapter == null)
                    s_typeOfDateTimeOffsetAdapter = typeof(DateTimeOffsetAdapter);
                return s_typeOfDateTimeOffsetAdapter;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfUri;
        internal static Type TypeOfUri
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfUri == null)
                    s_typeOfUri = typeof(Uri);
                return s_typeOfUri;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfTypeEnumerable;
        internal static Type TypeOfTypeEnumerable
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfTypeEnumerable == null)
                    s_typeOfTypeEnumerable = typeof(IEnumerable<Type>);
                return s_typeOfTypeEnumerable;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfStreamingContext;
        internal static Type TypeOfStreamingContext
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfStreamingContext == null)
                    s_typeOfStreamingContext = typeof(StreamingContext);
                return s_typeOfStreamingContext;
            }
        }


        [SecurityCritical]
        private static Type s_typeOfXmlFormatClassWriterDelegate;
        internal static Type TypeOfXmlFormatClassWriterDelegate
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfXmlFormatClassWriterDelegate == null)
                    s_typeOfXmlFormatClassWriterDelegate = typeof(XmlFormatClassWriterDelegate);
                return s_typeOfXmlFormatClassWriterDelegate;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfXmlFormatCollectionWriterDelegate;
        internal static Type TypeOfXmlFormatCollectionWriterDelegate
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfXmlFormatCollectionWriterDelegate == null)
                    s_typeOfXmlFormatCollectionWriterDelegate = typeof(XmlFormatCollectionWriterDelegate);
                return s_typeOfXmlFormatCollectionWriterDelegate;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfXmlFormatClassReaderDelegate;
        internal static Type TypeOfXmlFormatClassReaderDelegate
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfXmlFormatClassReaderDelegate == null)
                    s_typeOfXmlFormatClassReaderDelegate = typeof(XmlFormatClassReaderDelegate);
                return s_typeOfXmlFormatClassReaderDelegate;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfXmlFormatCollectionReaderDelegate;
        internal static Type TypeOfXmlFormatCollectionReaderDelegate
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfXmlFormatCollectionReaderDelegate == null)
                    s_typeOfXmlFormatCollectionReaderDelegate = typeof(XmlFormatCollectionReaderDelegate);
                return s_typeOfXmlFormatCollectionReaderDelegate;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfXmlFormatGetOnlyCollectionReaderDelegate;
        internal static Type TypeOfXmlFormatGetOnlyCollectionReaderDelegate
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfXmlFormatGetOnlyCollectionReaderDelegate == null)
                    s_typeOfXmlFormatGetOnlyCollectionReaderDelegate = typeof(XmlFormatGetOnlyCollectionReaderDelegate);
                return s_typeOfXmlFormatGetOnlyCollectionReaderDelegate;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfKnownTypeAttribute;
        internal static Type TypeOfKnownTypeAttribute
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfKnownTypeAttribute == null)
                    s_typeOfKnownTypeAttribute = typeof(KnownTypeAttribute);
                return s_typeOfKnownTypeAttribute;
            }
        }

        /// <SecurityNote>
        /// Critical - attrbute type used in security decision
        /// </SecurityNote>
        [SecurityCritical]
        private static Type s_typeOfDataContractAttribute;
        internal static Type TypeOfDataContractAttribute
        {
            /// <SecurityNote>
            /// Critical - accesses critical field for attribute type
            /// Safe - controls inputs and logic
            /// </SecurityNote>
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfDataContractAttribute == null)
                    s_typeOfDataContractAttribute = typeof(DataContractAttribute);
                return s_typeOfDataContractAttribute;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfDataMemberAttribute;
        internal static Type TypeOfDataMemberAttribute
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfDataMemberAttribute == null)
                    s_typeOfDataMemberAttribute = typeof(DataMemberAttribute);
                return s_typeOfDataMemberAttribute;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfEnumMemberAttribute;
        internal static Type TypeOfEnumMemberAttribute
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfEnumMemberAttribute == null)
                    s_typeOfEnumMemberAttribute = typeof(EnumMemberAttribute);
                return s_typeOfEnumMemberAttribute;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfCollectionDataContractAttribute;
        internal static Type TypeOfCollectionDataContractAttribute
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfCollectionDataContractAttribute == null)
                    s_typeOfCollectionDataContractAttribute = typeof(CollectionDataContractAttribute);
                return s_typeOfCollectionDataContractAttribute;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfObjectArray;
        internal static Type TypeOfObjectArray
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfObjectArray == null)
                    s_typeOfObjectArray = typeof(object[]);
                return s_typeOfObjectArray;
            }
        }


        [SecurityCritical]
        private static Type s_typeOfOnSerializingAttribute;
        internal static Type TypeOfOnSerializingAttribute
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfOnSerializingAttribute == null)
                    s_typeOfOnSerializingAttribute = typeof(OnSerializingAttribute);
                return s_typeOfOnSerializingAttribute;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfOnSerializedAttribute;
        internal static Type TypeOfOnSerializedAttribute
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfOnSerializedAttribute == null)
                    s_typeOfOnSerializedAttribute = typeof(OnSerializedAttribute);
                return s_typeOfOnSerializedAttribute;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfOnDeserializingAttribute;
        internal static Type TypeOfOnDeserializingAttribute
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfOnDeserializingAttribute == null)
                    s_typeOfOnDeserializingAttribute = typeof(OnDeserializingAttribute);
                return s_typeOfOnDeserializingAttribute;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfOnDeserializedAttribute;
        internal static Type TypeOfOnDeserializedAttribute
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfOnDeserializedAttribute == null)
                    s_typeOfOnDeserializedAttribute = typeof(OnDeserializedAttribute);
                return s_typeOfOnDeserializedAttribute;
            }
        }


        [SecurityCritical]
        private static Type s_typeOfFlagsAttribute;
        internal static Type TypeOfFlagsAttribute
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfFlagsAttribute == null)
                    s_typeOfFlagsAttribute = typeof(FlagsAttribute);
                return s_typeOfFlagsAttribute;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfIXmlSerializable;
        internal static Type TypeOfIXmlSerializable
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfIXmlSerializable == null)
                    s_typeOfIXmlSerializable = typeof(IXmlSerializable);
                return s_typeOfIXmlSerializable;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfXmlSchemaProviderAttribute;
        internal static Type TypeOfXmlSchemaProviderAttribute
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfXmlSchemaProviderAttribute == null)
                    s_typeOfXmlSchemaProviderAttribute = typeof(XmlSchemaProviderAttribute);
                return s_typeOfXmlSchemaProviderAttribute;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfXmlRootAttribute;
        internal static Type TypeOfXmlRootAttribute
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfXmlRootAttribute == null)
                    s_typeOfXmlRootAttribute = typeof(XmlRootAttribute);
                return s_typeOfXmlRootAttribute;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfXmlQualifiedName;
        internal static Type TypeOfXmlQualifiedName
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfXmlQualifiedName == null)
                    s_typeOfXmlQualifiedName = typeof(XmlQualifiedName);
                return s_typeOfXmlQualifiedName;
            }
        }

#if NET_NATIVE
        [SecurityCritical]
        private static Type s_typeOfISerializableDataNode;
        internal static Type TypeOfISerializableDataNode
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfISerializableDataNode == null)
                    s_typeOfISerializableDataNode = typeof(ISerializableDataNode);
                return s_typeOfISerializableDataNode;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfClassDataNode;
        internal static Type TypeOfClassDataNode
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfClassDataNode == null)
                    s_typeOfClassDataNode = typeof(ClassDataNode);
                return s_typeOfClassDataNode;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfCollectionDataNode;
        internal static Type TypeOfCollectionDataNode
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfCollectionDataNode == null)
                    s_typeOfCollectionDataNode = typeof(CollectionDataNode);
                return s_typeOfCollectionDataNode;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfSafeSerializationManager;
        private static bool s_typeOfSafeSerializationManagerSet;
        internal static Type TypeOfSafeSerializationManager
        {
            [SecuritySafeCritical]
            get
            {
                if (!s_typeOfSafeSerializationManagerSet)
                {
                    s_typeOfSafeSerializationManager = TypeOfInt.GetTypeInfo().Assembly.GetType("System.Runtime.Serialization.SafeSerializationManager");
                    s_typeOfSafeSerializationManagerSet = true;
                }
                return s_typeOfSafeSerializationManager;
            }
        }
#endif

        [SecurityCritical]
        private static Type s_typeOfNullable;
        internal static Type TypeOfNullable
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfNullable == null)
                    s_typeOfNullable = typeof(Nullable<>);
                return s_typeOfNullable;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfIDictionaryGeneric;
        internal static Type TypeOfIDictionaryGeneric
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfIDictionaryGeneric == null)
                    s_typeOfIDictionaryGeneric = typeof(IDictionary<,>);
                return s_typeOfIDictionaryGeneric;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfIDictionary;
        internal static Type TypeOfIDictionary
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfIDictionary == null)
                    s_typeOfIDictionary = typeof(IDictionary);
                return s_typeOfIDictionary;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfIListGeneric;
        internal static Type TypeOfIListGeneric
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfIListGeneric == null)
                    s_typeOfIListGeneric = typeof(IList<>);
                return s_typeOfIListGeneric;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfIList;
        internal static Type TypeOfIList
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfIList == null)
                    s_typeOfIList = typeof(IList);
                return s_typeOfIList;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfICollectionGeneric;
        internal static Type TypeOfICollectionGeneric
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfICollectionGeneric == null)
                    s_typeOfICollectionGeneric = typeof(ICollection<>);
                return s_typeOfICollectionGeneric;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfICollection;
        internal static Type TypeOfICollection
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfICollection == null)
                    s_typeOfICollection = typeof(ICollection);
                return s_typeOfICollection;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfIEnumerableGeneric;
        internal static Type TypeOfIEnumerableGeneric
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfIEnumerableGeneric == null)
                    s_typeOfIEnumerableGeneric = typeof(IEnumerable<>);
                return s_typeOfIEnumerableGeneric;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfIEnumerable;
        internal static Type TypeOfIEnumerable
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfIEnumerable == null)
                    s_typeOfIEnumerable = typeof(IEnumerable);
                return s_typeOfIEnumerable;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfIEnumeratorGeneric;
        internal static Type TypeOfIEnumeratorGeneric
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfIEnumeratorGeneric == null)
                    s_typeOfIEnumeratorGeneric = typeof(IEnumerator<>);
                return s_typeOfIEnumeratorGeneric;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfIEnumerator;
        internal static Type TypeOfIEnumerator
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfIEnumerator == null)
                    s_typeOfIEnumerator = typeof(IEnumerator);
                return s_typeOfIEnumerator;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfKeyValuePair;
        internal static Type TypeOfKeyValuePair
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfKeyValuePair == null)
                    s_typeOfKeyValuePair = typeof(KeyValuePair<,>);
                return s_typeOfKeyValuePair;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfKeyValuePairAdapter;
        internal static Type TypeOfKeyValuePairAdapter
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfKeyValuePairAdapter == null)
                    s_typeOfKeyValuePairAdapter = typeof(KeyValuePairAdapter<,>);
                return s_typeOfKeyValuePairAdapter;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfKeyValue;
        internal static Type TypeOfKeyValue
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfKeyValue == null)
                    s_typeOfKeyValue = typeof(KeyValue<,>);
                return s_typeOfKeyValue;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfIDictionaryEnumerator;
        internal static Type TypeOfIDictionaryEnumerator
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfIDictionaryEnumerator == null)
                    s_typeOfIDictionaryEnumerator = typeof(IDictionaryEnumerator);
                return s_typeOfIDictionaryEnumerator;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfDictionaryEnumerator;
        internal static Type TypeOfDictionaryEnumerator
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfDictionaryEnumerator == null)
                    s_typeOfDictionaryEnumerator = typeof(CollectionDataContract.DictionaryEnumerator);
                return s_typeOfDictionaryEnumerator;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfGenericDictionaryEnumerator;
        internal static Type TypeOfGenericDictionaryEnumerator
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfGenericDictionaryEnumerator == null)
                    s_typeOfGenericDictionaryEnumerator = typeof(CollectionDataContract.GenericDictionaryEnumerator<,>);
                return s_typeOfGenericDictionaryEnumerator;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfDictionaryGeneric;
        internal static Type TypeOfDictionaryGeneric
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfDictionaryGeneric == null)
                    s_typeOfDictionaryGeneric = typeof(Dictionary<,>);
                return s_typeOfDictionaryGeneric;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfHashtable;
        internal static Type TypeOfHashtable
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfHashtable == null)
                    s_typeOfHashtable = TypeOfDictionaryGeneric.MakeGenericType(TypeOfObject, TypeOfObject);
                return s_typeOfHashtable;
            }
        }

        [SecurityCritical]
        private static Type s_typeOfListGeneric;
        internal static Type TypeOfListGeneric
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfListGeneric == null)
                    s_typeOfListGeneric = typeof(List<>);
                return s_typeOfListGeneric;
            }
        }

        private static bool s_shouldGetDBNullType = true;

        [SecurityCritical]
        private static Type s_typeOfDBNull;
        internal static Type TypeOfDBNull
        {
            [SecuritySafeCritical]
            get
            {
                if (s_typeOfDBNull == null && s_shouldGetDBNullType)
                {
                    s_typeOfDBNull = Type.GetType("System.DBNull, System.Data.Common, Version=0.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false);
                    s_shouldGetDBNullType = false;
                }
                return s_typeOfDBNull;
            }
        }

        [SecurityCritical]
        private static object s_valueOfDBNull;
        internal static object ValueOfDBNull
        {
            [SecuritySafeCritical]
            get
            {
                if (s_valueOfDBNull == null && TypeOfDBNull != null)
                {
                    var fieldInfo = TypeOfDBNull.GetField("Value");
                    if (fieldInfo != null)
                        s_valueOfDBNull = fieldInfo.GetValue(null);
                }

                return s_valueOfDBNull;
            }
        }

        [SecurityCritical]
        private static Uri s_dataContractXsdBaseNamespaceUri;
        internal static Uri DataContractXsdBaseNamespaceUri
        {
            [SecuritySafeCritical]
            get
            {
                if (s_dataContractXsdBaseNamespaceUri == null)
                    s_dataContractXsdBaseNamespaceUri = new Uri(DataContractXsdBaseNamespace);
                return s_dataContractXsdBaseNamespaceUri;
            }
        }

        [SecurityCritical]
        private static string[] s_dataContractSerializationPatterns;
        internal static string[] DataContractSerializationPatterns
        {
            [SecuritySafeCritical]
            get
            {
                if (s_dataContractSerializationPatterns == null)
                    s_dataContractSerializationPatterns = new string[] { SimpleSRSInternalsVisiblePattern, FullSRSInternalsVisiblePattern };
                return s_dataContractSerializationPatterns;
            }
        }

        #region Contract compliance for System.Type

        private static bool TypeSequenceEqual(Type[] seq1, Type[] seq2)
        {
            if (seq1 == null || seq2 == null || seq1.Length != seq2.Length)
                return false;
            for (int i = 0; i < seq1.Length; i++)
            {
                if (!seq1[i].Equals(seq2[i]) && !seq1[i].IsAssignableFrom(seq2[i]))
                    return false;
            }
            return true;
        }

        private static MethodBase FilterMethodBases(MethodBase[] methodBases, Type[] parameterTypes, string methodName)
        {
            if (methodBases == null || string.IsNullOrEmpty(methodName))
                return null;

            var matchedMethods = methodBases.Where(method => method.Name.Equals(methodName));
            matchedMethods = matchedMethods.Where(method => TypeSequenceEqual(method.GetParameters().Select(param => param.ParameterType).ToArray(), parameterTypes));
            return matchedMethods.FirstOrDefault();
        }

        internal static ConstructorInfo GetConstructor(this Type type, BindingFlags bindingFlags, Type[] parameterTypes)
        {
            var constructorInfos = type.GetConstructors(bindingFlags);
            var constructorInfo = FilterMethodBases(constructorInfos.Cast<MethodBase>().ToArray(), parameterTypes, ".ctor");
            return constructorInfo != null ? (ConstructorInfo)constructorInfo : null;
        }

        internal static MethodInfo GetMethod(this Type type, string methodName, BindingFlags bindingFlags, Type[] parameterTypes)
        {
            var methodInfos = type.GetMethods(bindingFlags);
            var methodInfo = FilterMethodBases(methodInfos.Cast<MethodBase>().ToArray(), parameterTypes, methodName);
            return methodInfo != null ? (MethodInfo)methodInfo : null;
        }

        #endregion

        private static Type s_typeOfScriptObject;
        private static Func<object, string> s_serializeFunc;
        private static Func<string, object> s_deserializeFunc;

        internal static ClassDataContract CreateScriptObjectClassDataContract()
        {
            Debug.Assert(s_typeOfScriptObject != null);
            return new ClassDataContract(s_typeOfScriptObject);
        }

        internal static bool TypeOfScriptObject_IsAssignableFrom(Type type)
        {
            return s_typeOfScriptObject != null && s_typeOfScriptObject.IsAssignableFrom(type);
        }

        internal static void SetScriptObjectJsonSerializer(Type typeOfScriptObject, Func<object, string> serializeFunc, Func<string, object> deserializeFunc)
        {
            Globals.s_typeOfScriptObject = typeOfScriptObject;
            Globals.s_serializeFunc = serializeFunc;
            Globals.s_deserializeFunc = deserializeFunc;
        }

        internal static string ScriptObjectJsonSerialize(object obj)
        {
            Debug.Assert(s_serializeFunc != null);
            return Globals.s_serializeFunc(obj);
        }

        internal static object ScriptObjectJsonDeserialize(string json)
        {
            Debug.Assert(s_deserializeFunc != null);
            return Globals.s_deserializeFunc(json);
        }

        internal static bool IsDBNullValue(object o)
        {
            return o != null && ValueOfDBNull != null && ValueOfDBNull.Equals(o);
        }

        public const bool DefaultIsRequired = false;
        public const bool DefaultEmitDefaultValue = true;
        public const int DefaultOrder = 0;
        public const bool DefaultIsReference = false;
        // The value string.Empty aids comparisons (can do simple length checks
        //     instead of string comparison method calls in IL.)
        public readonly static string NewObjectId = string.Empty;
        public const string NullObjectId = null;
        public const string SimpleSRSInternalsVisiblePattern = @"^[\s]*System\.Runtime\.Serialization[\s]*$";
        public const string FullSRSInternalsVisiblePattern = @"^[\s]*System\.Runtime\.Serialization[\s]*,[\s]*PublicKey[\s]*=[\s]*(?i:00240000048000009400000006020000002400005253413100040000010001008d56c76f9e8649383049f383c44be0ec204181822a6c31cf5eb7ef486944d032188ea1d3920763712ccb12d75fb77e9811149e6148e5d32fbaab37611c1878ddc19e20ef135d0cb2cff2bfec3d115810c3d9069638fe4be215dbf795861920e5ab6f7db2e2ceef136ac23d5dd2bf031700aec232f6c6b1c785b4305c123b37ab)[\s]*$";
        public const string Space = " ";
        public const string XsiPrefix = "i";
        public const string XsdPrefix = "x";
        public const string SerPrefix = "z";
        public const string SerPrefixForSchema = "ser";
        public const string ElementPrefix = "q";
        public const string DataContractXsdBaseNamespace = "http://schemas.datacontract.org/2004/07/";
        public const string DataContractXmlNamespace = DataContractXsdBaseNamespace + "System.Xml";
        public const string SchemaInstanceNamespace = "http://www.w3.org/2001/XMLSchema-instance";
        public const string SchemaNamespace = "http://www.w3.org/2001/XMLSchema";
        public const string XsiNilLocalName = "nil";
        public const string XsiTypeLocalName = "type";
        public const string TnsPrefix = "tns";
        public const string OccursUnbounded = "unbounded";
        public const string AnyTypeLocalName = "anyType";
        public const string StringLocalName = "string";
        public const string IntLocalName = "int";
        public const string True = "true";
        public const string False = "false";
        public const string ArrayPrefix = "ArrayOf";
        public const string XmlnsNamespace = "http://www.w3.org/2000/xmlns/";
        public const string XmlnsPrefix = "xmlns";
        public const string SchemaLocalName = "schema";
        public const string CollectionsNamespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays";
        public const string DefaultClrNamespace = "GeneratedNamespace";
        public const string DefaultTypeName = "GeneratedType";
        public const string DefaultGeneratedMember = "GeneratedMember";
        public const string DefaultFieldSuffix = "Field";
        public const string DefaultPropertySuffix = "Property";
        public const string DefaultMemberSuffix = "Member";
        public const string NameProperty = "Name";
        public const string NamespaceProperty = "Namespace";
        public const string OrderProperty = "Order";
        public const string IsReferenceProperty = "IsReference";
        public const string IsRequiredProperty = "IsRequired";
        public const string EmitDefaultValueProperty = "EmitDefaultValue";
        public const string ClrNamespaceProperty = "ClrNamespace";
        public const string ItemNameProperty = "ItemName";
        public const string KeyNameProperty = "KeyName";
        public const string ValueNameProperty = "ValueName";
        public const string SerializationInfoPropertyName = "SerializationInfo";
        public const string SerializationInfoFieldName = "info";
        public const string NodeArrayPropertyName = "Nodes";
        public const string NodeArrayFieldName = "nodesField";
        public const string ExportSchemaMethod = "ExportSchema";
        public const string IsAnyProperty = "IsAny";
        public const string ContextFieldName = "context";
        public const string GetObjectDataMethodName = "GetObjectData";
        public const string GetEnumeratorMethodName = "GetEnumerator";
        public const string MoveNextMethodName = "MoveNext";
        public const string AddValueMethodName = "AddValue";
        public const string CurrentPropertyName = "Current";
        public const string ValueProperty = "Value";
        public const string EnumeratorFieldName = "enumerator";
        public const string SerializationEntryFieldName = "entry";
        public const string ExtensionDataSetMethod = "set_ExtensionData";
        public const string ExtensionDataSetExplicitMethod = "System.Runtime.Serialization.IExtensibleDataObject.set_ExtensionData";
        public const string ExtensionDataObjectPropertyName = "ExtensionData";
        public const string ExtensionDataObjectFieldName = "extensionDataField";
        public const string AddMethodName = "Add";
        public const string GetCurrentMethodName = "get_Current";
        // NOTE: These values are used in schema below. If you modify any value, please make the same change in the schema.
        public const string SerializationNamespace = "http://schemas.microsoft.com/2003/10/Serialization/";
        public const string ClrTypeLocalName = "Type";
        public const string ClrAssemblyLocalName = "Assembly";
        public const string IsValueTypeLocalName = "IsValueType";
        public const string EnumerationValueLocalName = "EnumerationValue";
        public const string SurrogateDataLocalName = "Surrogate";
        public const string GenericTypeLocalName = "GenericType";
        public const string GenericParameterLocalName = "GenericParameter";
        public const string GenericNameAttribute = "Name";
        public const string GenericNamespaceAttribute = "Namespace";
        public const string GenericParameterNestedLevelAttribute = "NestedLevel";
        public const string IsDictionaryLocalName = "IsDictionary";
        public const string ActualTypeLocalName = "ActualType";
        public const string ActualTypeNameAttribute = "Name";
        public const string ActualTypeNamespaceAttribute = "Namespace";
        public const string DefaultValueLocalName = "DefaultValue";
        public const string EmitDefaultValueAttribute = "EmitDefaultValue";
        public const string IdLocalName = "Id";
        public const string RefLocalName = "Ref";
        public const string ArraySizeLocalName = "Size";
        public const string KeyLocalName = "Key";
        public const string ValueLocalName = "Value";
        public const string MscorlibAssemblyName = "0";
#if !NET_NATIVE && MERGE_DCJS
        public const string ParseMethodName = "Parse";
#endif
#if NET_NATIVE || MERGE_DCJS
        public const string SafeSerializationManagerName = "SafeSerializationManager";
        public const string SafeSerializationManagerNamespace = "http://schemas.datacontract.org/2004/07/System.Runtime.Serialization";
        public const string ISerializableFactoryTypeLocalName = "FactoryType";
#endif
    }
}
