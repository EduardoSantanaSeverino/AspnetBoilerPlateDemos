#!/bin/bash

echo "Copy files started..."
echo ""

if [ -d "source/MyCollegeV2/aspnet-core/src/MyCollegeV2.Application/Students" ] ; then
    echo "Source file was found in source/MyCollegeV2/aspnet-core/src/MyCollegeV2.Application/Students"
    echo ""
else
    echo "ERROR: Source file was NOT found in source/MyCollegeV2/aspnet-core/src/MyCollegeV2.Application/Students"
    echo ""
    exit 1
fi

if [ -d "source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Application/Students" ] ; then
    echo "Deleting existing files source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Application/Students"
    echo ""
    rm -rf source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Application/Students
fi

echo "Copy Directory source/MyCollegeV2/aspnet-core/src/MyCollegeV2.Application/Students"
echo ""
cp -rf source/MyCollegeV2/aspnet-core/src/MyCollegeV2.Application/Students source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Application/

echo "Remove Bonus Files source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Application/Students/StudentAppServiceV2.cs"
echo ""
rm source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Application/Students/StudentAppServiceV2.cs

echo "Copy One file source/MyCollegeV2/aspnet-core/src/MyCollegeV2.Application/Students/StudentAppService.cs"
echo ""
cp -rf source/MyCollegeV2/aspnet-core/src/MyCollegeV2.Application/Students/StudentAppServiceV2.cs source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Application/Students/StudentAppService.cs


echo "Update Project Name:"
echo ""
for filename in $(find source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Application/Students -name '*.cs'); do
    echo "Update Project Name in file: $filename"
    sed -i '' 's/MyCollegeV2/MyCollegeV1/g' $filename # for Mac
    # sed -i -e 's/MyCollegeV2/MyCollegeV1/g' $filename # for Linux or Windows
done
echo ""

echo "Update Class name:"
echo ""
for filename in $(find source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Application/Students -name 'StudentAppService.cs'); do
    echo "Update Project Name in file: $filename"
    sed -i '' 's/StudentAppServiceV2/StudentAppService/g' $filename # for Mac
    # sed -i -e 's/StudentAppServiceV2/StudentAppService/g' $filename # for Linux or Windows
done
echo ""

echo "Copy completed.."
echo ""
